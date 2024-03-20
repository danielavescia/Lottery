import React, { useState } from "react";
import "./number-selector.css";

function createArrayNumbers() {
    var numbers = [];
    for (var i = 1; i < 51; i++) {
        numbers.push(i);
    }
    return numbers;
}

function NumberSelector(props) {

    const selectedNumber = props.selectedNumber;

    const [errors, setErros] = useState() //creating state for errors

    var numbers = createArrayNumbers(); //creating array of numbers in the range 0-50

    const handleNumberClick = (number) => {
       
        if (selectedNumber.includes(null)) {   //if array its not full
            let index = selectedNumber.indexOf(null); //receives the first index that has null
            selectedNumber[index] = number; //receives the clicked number into the index

        } else {
            selectedNumber.shift(); //eliminates the first one in the array
            selectedNumber.push(number); //push the number to the end
        }   
        
        console.log(selectedNumber); 
    };
   
    return (
        <div className="gamble-container">
            <div className="number-selector-container">
                {numbers.map((number) => (
                    <div
                        key={number}
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
