// src/hooks/useBoardSync.tsx
import { useCallback, useEffect, useRef, useState } from "react";
import { Board } from "../types/BoardTypes";
import { useLocalStorage } from "./useLocalStorage";
import { BoardUtils } from "../utils/boardUtils";

export const useBoardSync = () => {
  const [board, setStoredBoard, removeStoredBoard] = useLocalStorage<Board>(
    `board-current`, 
    BoardUtils.emptyBoard()
  );
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const initializedRef = useRef(false);

  // Update both backend and local storage
  const updateBoard = useCallback(async (updatedBoard: Board) => {
    try {
      setLoading(true);
      setError(null);

      const response = await fetch(`${process.env.REACT_APP_API_BASE_URL}/api/Board/${updatedBoard.id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updatedBoard)
      });

      if (!response.ok) {
        throw new Error('Failed to update board on server');
      }

      const serverBoard = await response.json();
      
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
  }, [setStoredBoard, removeStoredBoard]);

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
  }, [setStoredBoard]);

  // Initialize backend with empty board if none exists
  useEffect(() => {
    if (!initializedRef.current && !board.id) {
      initializedRef.current = true;
      createBoard(board);
    }
  }, [board, createBoard]);
  
  return {
    board,
    loading,
    error,
    updateBoard,
    createBoard,
    fetchBoard,
    setStoredBoard
  };
};