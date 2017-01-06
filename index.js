const express = require('express');
const path = require('path');

const app = express();
const index = path.resolve('./index.html');

app.use(express.static('./'));

app.get('/*', (req, res) => (res.sendFile(index)));

app.listen(8000);
