import { useState } from "react";
import Welcome from "../Welcome/Welcome.js";
import Counter from "../Counter/Counter.js";
import Interest from "../Interest/Interest.js";
import Pokedex from "../Pokedex/Pokedex.js";

function SwitchPage(props) {
  switch (props.value) {
    case "welcome":
      return <Welcome></Welcome>;
    case "counter":
      return <Counter></Counter>;
    case "interest":
      return <Interest></Interest>;
    case "pokedex":
      return <Pokedex></Pokedex>;
    default:
      <div></div>;
  }
}

function Selector() {
  const defaultOption = "welcome";
  const [option, setOption] = useState(defaultOption);

  function handleSelect(event) {
    setOption(event.target.value);
  }

  return (
    <div className="Selector">
      <select name="pages" defaultValue={defaultOption} onChange={handleSelect}>
        <option value="welcome">Welcome</option>
        <option value="counter">Counter</option>
        <option value="interest">Interest</option>
        <option value="pokedex">Pokemon</option>
      </select>
      <p>Option selected: {option}</p>
      <SwitchPage value={option}></SwitchPage>
    </div>
  );
}

export default Selector;
