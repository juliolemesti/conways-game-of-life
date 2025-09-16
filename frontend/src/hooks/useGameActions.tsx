import { useCallback, useState } from "react";
import { Board } from "../types/BoardTypes";
import { BoardUtils } from "../utils/boardUtils";

interface useGameActionsProps {
  board: Board;
  updateBoard: (board: Board, synchApi: boolean) => Promise<Board>;
}

interface useGameActionsReturn {  
  getNextGeneration: () => Promise<void>;
}

export const useGameActions = ({ board, updateBoard }: useGameActionsProps): useGameActionsReturn => {
  const getNextGeneration = useCallback(async () => {
    try {
      const response = await fetch(`${process.env.REACT_APP_API_BASE_URL}/api/Game/NextGeneration`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(board)
      });
      if (!response.ok) {
        throw new Error('Failed to get next generation');
      }
      const data = await response.json();
      updateBoard(data, false);
    } catch (error) {
      console.error(error);
    }
  }, [board, updateBoard])

  return {
    getNextGeneration
  }
}