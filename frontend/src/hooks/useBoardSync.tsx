// src/hooks/useBoardSync.tsx
import { useCallback, useEffect, useRef, useState } from "react";
import { Board } from "../types/BoardTypes";
import { useLocalStorage } from "./useLocalStorage";
import { BoardUtils } from "../utils/boardUtils";
import { useBoardApi } from "./useBoardApi";
import { useGameActions } from "./useGameActions";

export const useBoardSync = () => {
  const [board, setStoredBoard, removeStoredBoard] = useLocalStorage<Board>(
    `board-current`,
    BoardUtils.emptyBoard()
  );

  const { updateBoard, createBoard, fetchBoard, loading, error } = useBoardApi({ board, setStoredBoard, removeStoredBoard })

  const { getNextGeneration } = useGameActions({ board, updateBoard });

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