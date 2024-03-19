import React, { useState } from "react";
import "./number-selector.css";

function createArrayNumbers() {
    var numbers = [];
    for (var i = 1; i < 51; i++) {
        numbers.push(i);
    }
    return numbers;
}

function NumberSelector() {

    const [selectedNumbers, setSelectedNumber] = useState({     //creating state for selectednumbers
        number1: null,
        number2: null,
        number3: null,
        number4: null,
        number5: null,
    });

    const [errors, setErros] = useState({}) //creating state for errors

    var numbers = createArrayNumbers(); //creating array of numbers in the range 0-50

    const handleNumberClick = (number) => {
        //setSelectedNumber(number);
    };

    return (
        <div className="gamble-container">
            <div className="number-selector-container">
                {numbers.map((number) => (
                    <div
                        key={number - 1}
                        className="div-number"
                        onClick={() => handleNumberClick(number)}
                        value={number}
                    >
                        {number}
                    </div>
                ))}
            </div>
        </div>
    );
}

export default NumberSelector;
