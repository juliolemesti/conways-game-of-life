import React, { useCallback, useEffect, useMemo, useState } from "react";
import { useBoardSync } from "../hooks/useBoardSync";
import { BoardUtils } from "../utils/boardUtils";
import { DEFAUL_BOARD_SIZE } from "../utils/constants";
import { Cell } from "./Cell";
import './GameBoard.css';

interface GameBoardProps {
  initialSize?: number;
}

export const GameBoard: React.FC<GameBoardProps> = ({ initialSize = DEFAUL_BOARD_SIZE }) => {
  const { board, loading, error, updateBoard, createBoard, fetchBoard } = useBoardSync();
  const { id, boardSize, generation } = board ?? {};

  const [grid, setGrid] = useState<boolean[][]>(board?.grid ?? BoardUtils.initializeGrid());

  useEffect(() => {
    setGrid(board?.grid ?? []);
  }, [board?.grid]);

  const handleSizeChange = useCallback((newSize: number) => {
  }, []);

  const handleClearBoard = useCallback(() => {
    setGrid(BoardUtils.initializeGrid());
  }, []);

  const handleCellClick = useCallback((row: number, column: number) => {
    const newGrid = grid.map((rowArray, rowIndex) =>
      rowArray.map((isAlive, columnIndex) =>
        (rowIndex === row && columnIndex === column) ? !isAlive : isAlive
      )
    );
    setGrid(newGrid);

  }, [grid]);

  const handleNextGeneration = useCallback(() => {

  }, []);

  useEffect(() => {
  }, []);

  const gridStyle = useMemo(() => ({
    gridTemplateColumns: `repeat(${boardSize}, 1fr)`,
    gridTemplateRows: `repeat(${boardSize}, 1fr)`
  }), [boardSize]);

  return (
    <div className="game-board-container">
      <div className="game-board-controls">
        <div className="size-control">
          <label htmlFor="board-size">Board Size:</label>
          <select
            id="board-size"
            value={boardSize}
            onChange={(e) => handleSizeChange(Number(e.target.value))}
          >
            <option value={20}>20x20</option>
            <option value={30}>30x30</option>
            <option value={40}>40x40</option>
            <option value={50}>50x50</option>
          </select>
        </div>

        <div className="board-actions">
          <button onClick={handleNextGeneration} className="btn btn-primary">
            Next
          </button>
          <button onClick={handleClearBoard} className="btn btn-primary">
            Clear Board
          </button>
        </div>
      </div>


      <div
        className="game-board-grid"
        style={gridStyle}
        role="grid"
        aria-label={`Game of Life board, ${boardSize} by ${boardSize} cells`}
      >
        {grid.map((row, rowIndex) =>
          row.map((isAlive, columnIndex) => (
            <Cell
              key={`${rowIndex}-${columnIndex}`}
              isAlive={isAlive}
              row={rowIndex}
              column={columnIndex}
              onCellClick={handleCellClick}
            />
          ))
        )}
      </div>

      <div className="board-info">
        <p>Click cells to toggle their state</p>
        <p>Board Size: {boardSize}x{boardSize}</p>
        <p>Alive Cells: {grid.flat().filter(Boolean).length}</p>
      </div>
    </div>
  );
};