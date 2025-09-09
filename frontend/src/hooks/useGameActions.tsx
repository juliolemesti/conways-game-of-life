import { useCallback } from "react";

export const useGameActions = () => {
  const handleNextGeneration = useCallback(() => {
    console.log("Next Generation");
    
  }, [])
}