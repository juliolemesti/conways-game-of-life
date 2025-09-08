import React from 'react';
import { GameBoard } from '../components/GameBoard';

const GameBoardPage: React.FC<{}> = () => {
  return (
    <div style={{ textAlign: 'center' }}>
      <p>Click cells to toggle their state and create patterns</p>

      <GameBoard />
    </div>
  );
};

export default GameBoardPage;