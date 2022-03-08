import { useState } from "react";
import "./Counter.css";

function Counter() {
  const [count, setCount] = useState(0);

  return (
    <div className="Counter">
      <button
        className="counter-button"
        onClick={() => (count > 0 ? setCount(count - 1) : setCount(0))}
      >
        -
      </button>
      <div className="count-number">{count}</div>
      <button className="counter-button" onClick={() => setCount(count + 1)}>
        +
      </button>
    </div>
  );
}

export default Counter;
