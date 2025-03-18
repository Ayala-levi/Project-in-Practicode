import express from 'express'
import cors from 'cors'
import routep from './rout.js';

//http://localhost:8080/render-projects/getAll

const app=express()
app.use(cors())

app.get("/",()=>"Publishing a Node app")

app.use('/render-projects',routep)

app.listen("8080",()=>{console.log("run barouch hashem")})


