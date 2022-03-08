import { useState } from "react";

const defaultState = { coding: false, music: false, reading: false };

function Interest() {
  const [optionState, setOptionState] = useState(defaultState);

  function handleCheckbox(event) {
    switch (event.target.value) {
      case "all":
        setOptionState({
          coding: !optionState.coding,
          music: !optionState.music,
          reading: !optionState.reading,
        });
        break;
      case "coding":
        setOptionState({ ...optionState, coding: !optionState.coding });
        break;
      case "music":
        setOptionState({ ...optionState, music: !optionState.music });
        break;
      case "reading":
        setOptionState({ ...optionState, reading: !optionState.reading });
        break;
      default:
        setOptionState(defaultState);
        break;
    }
  }

  return (
    <div className="Interest">
      <label>
        <input
          type="checkbox"
          name="all"
          value="all"
          onChange={handleCheckbox}
          checked={
            optionState.coding && optionState.music && optionState.reading
          }
        />
        All
      </label>
      <label>
        <input
          type="checkbox"
          name="coding"
          value="coding"
          onChange={handleCheckbox}
          checked={optionState.coding}
        />{" "}
        Coding
      </label>
      <label>
        <input
          type="checkbox"
          name="music"
          value="music"
          onChange={handleCheckbox}
          checked={optionState.music}
        />{" "}
        Music
      </label>
      <label>
        <input
          type="checkbox"
          name="reading"
          value="reading"
          onChange={handleCheckbox}
          checked={optionState.reading}
        />{" "}
        Reading Books
      </label>

      <p>You selected: {JSON.stringify(optionState, null, 2)}</p>
    </div>
  );
}

export default Interest;
