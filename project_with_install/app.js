import express from 'express';
import cors from 'cors';
import routep from './rout.js';

const app = express();
const port = process.env.PORT || 8080;

app.use(cors());

app.get("/", (req, res) => {
    res.send("Publishing a Node app");
});

app.use('/render-projects', routep);

app.listen(port, () => {
    console.log(`Server is running on port ${port}`);
});

// import express from 'express'
// import cors from 'cors'
// import routep from './rout.js';

// //http://localhost:8080/render-projects/getAll

// const app=express()

// app.use(cors())

// app.get("/",()=>"Publishing a Node app")

// app.use('/render-projects',routep)

// app.listen("8080",()=>{console.log("run barouch hashem")})