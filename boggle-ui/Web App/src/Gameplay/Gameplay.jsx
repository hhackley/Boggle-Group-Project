import { useState } from 'react';
import './Gameplay.scss';
import io from 'socket.io-client';
import { useEffect } from 'react';
import axios from 'axios';

const socket = io.connect('http://localhost:80', {
  withCredentials: true
});

export function Gameplay() {
    const [isGameStarted, setIsGameStarted] = useState(true);
    const [thisPlayer, setThisPlayer] = useState();
    let currentPlayer = {};
    const [wordInput, setWordInput] = useState('');
    const [hasJoinedMidSession, setHasJoinedMidSession] = useState(false);
    const [timeLeft, setTimeLeft] = useState(180);
    const [boardLetters, setBoardLetters] = useState([
        ['A', 'B', 'C', 'D'],
        ['E', 'F', 'G', 'H'],
        ['I', 'J', 'K', 'L'],
        ['M', 'N', 'O', 'P'],
    ]);
    const [players, setPlayers] = useState([]);
    const [wordsGuessed, setWordsGuessed] = useState([]);
    const adjectives = ['Beautiful','Happy','Silly','Clever','Graceful','Magnificent','Radiant','Elegant','Spunky','Cheerful','Sparkling','Vivacious','Poised','Playful','Lively'];
    const nouns = ['table','book','dog','car','flower','tree','desk','house','chair','pencil','phone','computer','bowl','spoon','fork'];

    useEffect(() => {
        const playerInfo = {Id: Math.floor(Math.random()*1000000), 
            Username: adjectives[Math.floor(Math.random()*adjectives.length)] + " " + nouns[Math.floor(Math.random()*nouns.length)], 
            Score: 0};
        currentPlayer = playerInfo;
        setThisPlayer(playerInfo);
        socket.emit("player-joined", playerInfo);
        socket.emit("is-game-in-session", playerInfo);
        socket.on("game-in-session-status", (update) => {
            if ((update.player.Id === playerInfo.Id) && update.status) {
                setHasJoinedMidSession(true);
            }
        })
        socket.emit("is-game-started");
        socket.on("is-game-started", (isStarted) => {
            setIsGameStarted(isStarted);

        })
    
        socket.on("game-started", (shuffledBoard) => {
            setBoardLetters(shuffledBoard);
            setHasJoinedMidSession(false);
        });

        socket.on("update-player-info", (playersInfo) => {
                for (const player of playersInfo.slice()) {
                    if (player.Id === currentPlayer.Id) {
                        currentPlayer = player;
                        setThisPlayer(player);
                    }
                }
            setPlayers(playersInfo);
        });
        
        socket.on("time-left", (seconds) => {
            setTimeLeft(seconds);
        })
    }, []);

    const enterClick = () => {
        socket.emit("word-guess", {PlayerId: thisPlayer.Id, Word: wordInput.toUpperCase()});
        setWordsGuessed(wordsGuessed => [...wordsGuessed, wordInput]);
        setWordInput("");
    }

    const inputKeyPressed = (e) => {
        if (e.key === 'Enter') enterClick();
    }

    const startGame = () => {
        setIsGameStarted(true);
        socket.emit("start-game");
    }

    return(
        <>
            <div className='timer'>{timeLeft}</div>
            {!isGameStarted ? 
            <div className='start-game-container' onClick={startGame}>
                Start Game!
            </div> : <></>}
            {hasJoinedMidSession ? 
            <div className='joined-mid-session-popup'>
                Game already in session.
            </div> : <></>}
            <div className="gameplay-container">
            <div className="game-title">
                Boggle
            </div>
            <div className='grid-and-leaderboard'>
                <div className='grid-container'>
                    {boardLetters.map(row => (
                        row.map(letter => (
                            <div className='grid-item'>{letter}</div>
                        ))
                    ))}
                </div>
                <div className='leaderboard-container'>
                    <div className='leaderboard-header'>Leaderboard:</div>
                    {players.sort((a, b) => b.Score - a.Score).map(player => (
                        <div className='leaderboard-player-container'>
                            <div className='leaderboard-player-score' style={thisPlayer ? (player.Id === thisPlayer.Id ? {fontWeight: 1000} : {}) : {}}>{player.Score}</div>
                            &nbsp;
                            <div className='leaderboard-player-name' style={thisPlayer ? (player.Id === thisPlayer.Id ? {fontWeight: 1000} : {}) : {}}>{player.Username}</div>
                        </div>
                    ))}
                </div>
            </div>
            <div className='word-bank'>
                <div className='word-bank-header'>
                    <div className='word-guess-search'>
                        <input className='word-guess-input' disabled={!isGameStarted || hasJoinedMidSession} value={wordInput} onKeyDown={inputKeyPressed} onChange={(e) => setWordInput(e.target.value)}></input>
                        <button className='word-guess-enter' disabled={!isGameStarted || hasJoinedMidSession} onClick={enterClick}>Enter</button>
                    </div>
                    <div className='player-score'>Score: {thisPlayer != null ? thisPlayer.Score : 0}</div>
                </div> 
                <div className='word-bank-words'>
                    {wordsGuessed.map(word => (
                        <div className='word-bank-word'>{word}</div>
                    ))}
                </div>
            </div>
        </div>
        </>
    );
}