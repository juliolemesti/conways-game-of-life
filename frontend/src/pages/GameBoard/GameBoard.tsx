import React, { useCallback, useState } from 'react';
import './GameBoard.css';

interface GameBoardProps {
  initialSize?: number;
}

const GameBoard: React.FC<GameBoardProps> = ({ initialSize = 60 }) => {
  const [boardSize, setBoardSize] = useState(initialSize);

  // Initialize board with all dead cells
  const initializeBoard = useCallback((size: number): boolean[][] => {
    return Array(size).fill(null).map(() => Array(size).fill(false));
  }, []);

  const [cells, setCells] = useState<boolean[][]>(() => initializeBoard(boardSize));

  const handleSizeChange = useCallback((newSize: number) => {
    setBoardSize(newSize);
    setCells(initializeBoard(newSize));
  }, [initializeBoard]);

  const handleClearBoard = useCallback(() => {
    setCells(initializeBoard(boardSize));
  }, [initializeBoard, boardSize]);

  return (
    <div className="game-board-container">
      <h1>Game Board</h1>

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
            <option value={60}>60x60</option>
            <option value={70}>70x70</option>
            <option value={80}>80x80</option>
            <option value={90}>90x90</option>
            <option value={100}>100x100</option>
          </select>
        </div>

        <div className="board-actions">
          <button onClick={handleClearBoard} className="btn btn-secondary">
            Clear Board
          </button>
        </div>
      </div>
    </div>
  );
};

export default GameBoard;