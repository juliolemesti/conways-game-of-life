import { useCallback, useState } from "react";
import { Board } from "../types/BoardTypes";

interface useBoardApiProps {
  board: Board,
  setStoredBoard: (board: Board) => void,
  removeStoredBoard: () => void
}

interface UseBoardApiReturn {
  loading: boolean;
  error: string | null;
  updateBoard: (updatedBoard: Board, synchApi: boolean) => Promise<Board>;
  createBoard: (newBoard: Omit<Board, 'id'>) => Promise<Board>;
  fetchBoard: (id: string) => Promise<Board>;
}

export const useBoardApi = ({
  board,
  setStoredBoard,
  removeStoredBoard
}: useBoardApiProps): UseBoardApiReturn => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const updateBoard = useCallback(async (updatedBoard: Board, synchApi: boolean = true) => {
    try {
      setStoredBoard(updatedBoard)
      if (!synchApi) return

      setLoading(true)
      setError(null)

      const response = await fetch(`${process.env.REACT_APP_API_BASE_URL}/api/Board/${updatedBoard.id}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updatedBoard)
      });

      if (!response.ok) {
        throw new Error('Failed to update board on server');
      }

      const serverBoard = await response.json()

      setStoredBoard(serverBoard);

      return serverBoard;
    } catch (error) {
      setError(error instanceof Error ? error.message : 'Unknown error');
      throw error;
    } finally {
      setLoading(false);
    }
  }, [setStoredBoard]);

  // Create new board (both backend and local storage)
  const createBoard = useCallback(async (newBoard: Omit<Board, 'id'>) => {
    try {
      setLoading(true);
      setError(null);

      setStoredBoard(newBoard);

      const response = await fetch(`${process.env.REACT_APP_API_BASE_URL}/api/Board`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newBoard)
      });

      if (!response.ok) {
        throw new Error('Failed to create board');
      }

      const createdBoard = await response.json();

      setStoredBoard(createdBoard);

      return createdBoard;
    } catch (error) {
      setError(error instanceof Error ? error.message : 'Unknown error');
      removeStoredBoard();
      throw error;
    } finally {
      setLoading(false);
    }
  }, [setStoredBoard, removeStoredBoard])

  // Fetch from backend and sync with local storage
  const fetchBoard = useCallback(async (id: string) => {
    try {
      setLoading(true);
      setError(null);

      const response = await fetch(`${process.env.REACT_APP_API_BASE_URL}/api/Board/${id}`);

      if (!response.ok) {
        throw new Error('Failed to fetch board');
      }

      const board = await response.json();

      // Update local storage with fetched data
      setStoredBoard(board);

      return board;
    } catch (error) {
      setError(error instanceof Error ? error.message : 'Unknown error');
      throw error;
    } finally {
      setLoading(false);
    }
  }, [setStoredBoard])

  return {
    loading,
    error,
    updateBoard,
    createBoard,
    fetchBoard
  }
}