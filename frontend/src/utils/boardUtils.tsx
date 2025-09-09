import { Board } from "../types/BoardTypes";
import { DEFAUL_BOARD_SIZE } from "./constants";

export const BoardUtils = {
  initializeGrid: (size: number = DEFAUL_BOARD_SIZE): boolean[][] => {
    return Array(size).fill(null).map(() => Array(size).fill(false));
  },
  emptyBoard: (size: number = DEFAUL_BOARD_SIZE): Board => {
    return {
      name: "Empty Board",
      boardSize: size,
      generation: 1,
      initialGrid: BoardUtils.initializeGrid(size)
    }
  }
}