import { Router} from 'express'
import funcs from './controller.js'

let routep=Router()

routep.get('/getAll',funcs.getAll)

export default routep
