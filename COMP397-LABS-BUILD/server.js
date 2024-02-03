const express = require('express');
const app = express();
const http = require('http');  
const path = require('path');
const port = 8000;

app.use(express.static(path.join(__dirname, '/')));

app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, 'index.html'));
});

http.createServer(app).listen(port, () => {
    console.log(`Server running on http://localhost:${port}`);
});

