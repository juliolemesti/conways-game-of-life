import React, { memo } from 'react';
import './Cell.css';

interface CellProps {
  isAlive: boolean;
  row: number;
  column: number;
  onCellClick: (row: number, column: number) => void;
}

export const Cell: React.FC<CellProps> = memo(({ isAlive, row, column, onCellClick }) => {
  const handleClick = () => {
    onCellClick(row, column);
  };

  return (
    <div
      className={`cell ${isAlive ? 'cell--alive' : 'cell--dead'}`}
      onClick={handleClick}
      role="button"
      tabIndex={0}
      aria-label={`Cell at row ${row}, column ${column}, ${isAlive ? 'alive' : 'dead'}`}
      onKeyDown={(e) => {
        if (e.key === 'Enter' || e.key === ' ') {
          e.preventDefault();
          handleClick();
        }
      }}
    />
  );
});

Cell.displayName = 'Cell';