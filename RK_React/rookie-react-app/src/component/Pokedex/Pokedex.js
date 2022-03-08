import { useEffect, useState } from "react";
import { Spinner } from "react-bootstrap";
import "./Pokedex.css";

function Pokedex() {
  const defaultPokemon = {
    id: 0,
    name: "pokemon",
    sprites: { back_default: "", front_default: "" },
    weight: 0,
  };
  const [pokemon, setPokemon] = useState(defaultPokemon);
  const [pokeId, setpokeId] = useState(1);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");

  const controller = new AbortController();

  function fetchPokemon(id) {
    fetch("https://pokeapi.co/api/v2/pokemon/" + id)
      .then((response) => {
        if (response.ok) return response.json();
        throw response;
      })
      .then((data) => {
        setPokemon(data);
      })
      .catch((err) => {
        console.log("Error loading pokemon", err);
        setError(error);
      })
      .finally(() => setLoading(false));
  }

  useEffect(() => {
    if (loading === true || pokemon.id === 0) {
      fetchPokemon(pokeId);
      setTimeout(() => controller.abort(), 5000);
    }
  }, [pokeId]);

  return (
    <div className="Pokemon">
      <div className="main">
        {loading === true ? (
          <Spinner animation="border" role="status" />
        ) : error === "" ? (
          <div className="pokemon-info">
            <p>ID: {pokemon.id}</p>
            <p>Name: {pokemon.name}</p>
            <p>Weight: {pokemon.weight}</p>
            <div className="pokemon-sprite">
              <img
                src={pokemon.sprites.front_default}
                alt={pokemon.name + " front sprite"}
              />
              <img
                src={pokemon.sprites.back_default}
                alt={pokemon.name + " back sprite"}
              />
            </div>
          </div>
        ) : (
          <p>Error loading pokemon: {error}</p>
        )}
      </div>
      <button
        onClick={() => {
          if (pokeId - 1 > 0) {
            setLoading(true);
            setpokeId(pokeId - 1);
          }
        }}
        disabled={loading}
      >
        Previous
      </button>
      <button
        onClick={() => {
          setLoading(true);
          setpokeId(pokeId + 1);
        }}
        disabled={loading}
      >
        Next
      </button>
    </div>
  );
}

export default Pokedex;
