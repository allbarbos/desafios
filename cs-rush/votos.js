'use strict';

const fs = require('fs');

process.stdin.resume();
process.stdin.setEncoding('utf-8');

let inputString = '';
let currentLine = 0;

process.stdin.on('data', function(inputStdin) {
    inputString += inputStdin;
});

process.stdin.on('end', function() {
    inputString = inputString.split('\n');

    main();
});

function readLine() {
    return inputString[currentLine++];
}


/*
 * Complete the 'writeIn' function below.
 *
 * The function is expected to return a STRING.
 * The function accepts STRING_ARRAY ballot as parameter.
 */

const sortAsc = (fieldName) => (a, b) => {
  if (a[fieldName] < b[fieldName])
    return -1;
  if (a[fieldName] > b[fieldName])
    return 1;
  return 0;
}


const groupList = list =>
  list.reduce((acc, cur) => {
    if (!cur) return {};
    cur in acc ? acc[cur]++ : acc[cur] = 1;
    return acc;
  }, {});

function writeIn(ballot) {
    const objBallot = groupList(ballot);

    const maxValue = Math.max(...Object.values(objBallot));

    const listVotes = Object.keys(objBallot)
    .map(key => ({ name: key, votes: objBallot[key] }));

    const maxVotes = listVotes.sort(sortAsc('name')).filter(item => item.votes === maxValue);

    const {name} = maxVotes[maxVotes.length - 1];

    return name  
    
    // let biridin = {};
    
    // ballot.sort().map(value => {
    //     value in biridin ? biridin[value]++ : biridin[value] = 1
    // })

    // const result = Object.keys(biridin).map(function(key) {
    //     return {key: biridin[key]};
    // });



    // const teste = Object.values(biridin).reduce((acc, cur, idx) => {
    //     return acc >= cur ? acc : cur
    // })



    //console.log(result)
}

function main() {