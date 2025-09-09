export type Board = {
  id?: number;
  name: string;
  boardSize: number;
  generation: number;
  grid?: boolean[][];
  initialGrid: boolean[][];
};
