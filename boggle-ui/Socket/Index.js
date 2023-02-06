const axios = require('axios');
const app = require("express")();
const http = require("http").Server(app);
const io = require("socket.io")(http, {
  cors: {
    origin: ['http://localhost:8080', 'http://localhost:8080/'],
    credentials: true
  }
});
process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = 0;
let players = [];
let isGameStarted = false;
io.on("connection", (socket) => {
  console.log('a user connected');

  socket.on("player-joined", (playerInfo) => {
    players.push(playerInfo);
    io.emit("update-player-info", players);
  })

  socket.on("is-game-started", () => {
    io.emit("is-game-started", isGameStarted);
  });

  socket.on("is-game-in-session", (playerInfo) => {
    io.emit("game-in-session-status", {status: isGameStarted, player: playerInfo});
  })

  /* retrieve word guessed 
  send to backend to check if it is valid
  get score as return value
  send score to all users for leaderboard
  */
  socket.on("word-guess", (playerWord) => {
    // send guess to backend
    console.log("Word guessed:", playerWord.Word);
    axios.post(`https://localhost:7147/api/WordClient?wordGuessed=${playerWord.Word}&playerId=${playerWord.PlayerId}`).then((isValid) => {
      if (isValid) {
        axios.get(`https://localhost:7147/api/ScoreClient?playerId=${playerWord.PlayerId}`).then((score) => {
          for (let player of players) {
            if (player.Id === playerWord.PlayerId) {
              player.Score = score.data;
              break;
            }
          }
          io.emit("update-player-info", players);
        });
      }
    });
  });

  socket.on("start-game", () => {
    // send request to start game
    // get board that is created.
    axios.delete('https://localhost:7147/api/WordClient').then(() => {
      axios.delete('https://localhost:7147/api/PlayerClient').then(() => {
        axios.post('https://localhost:7147/api/PlayerClient', players).then(() => {
          axios.get('https://localhost:7147/api/BoardClient').then((board) => {
            const boardArray = [];
            for (const player of players) {
              player.Score = 0;
            }
            io.emit("update-player-info", players);
            iBoard = [];
            for (let i = 0; i < board.data.length; i++) {
              iBoard.push(board.data[i]);
              if (iBoard.length === 4) {
                boardArray.push(iBoard);
                iBoard = [];
              }
            }
            io.emit("game-started", boardArray);
            let secondsLeft = 180;
            isGameStarted = true;
            io.emit("is-game-started", true);
            let interval = setInterval(() => {
              secondsLeft -= 1;
              console.log(secondsLeft);
              io.emit("time-left", secondsLeft);
              if (secondsLeft <= 0) {
                isGameStarted = false;
                console.log("game ended");
                io.emit("is-game-started", false);
                clearInterval(interval);
              }
            }, 1000);
          });
        })
      });
    });
  });

  socket.on('disconnect', () => {
    console.log('a user disconnected');
  });
});

http.listen(80, () => {
  console.log("listening on *:80");
});