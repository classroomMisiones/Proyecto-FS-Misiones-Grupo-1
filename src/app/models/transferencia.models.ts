export class Transferencias{
    constructor(
        public  idTranferencia: number,
        public  idCarteraOrigen: number,
        public  idClienteDestino: number,
        public  monto: number, 
    ){
        
    }
}