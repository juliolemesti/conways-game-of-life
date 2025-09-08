import './App.css';
import GameBoardPage from './pages/GameBoardPage';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>Conway's Game of Life</h1>
      </header>
      <main className="app-main">
        <GameBoardPage />
      </main>
    </div>
  );
}

export default App;
