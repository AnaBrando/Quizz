var resposta = [];

function inserirPegunta() {
 
    let resposta = document.querySelector(".resposta").value;
    let A = document.querySelector(".A").value;
    let B = document.querySelector(".B").value;
    let C = document.querySelector(".C").value;
    let D = document.querySelector(".D").value;
    let bingo = document.querySelector(".respostaCerta").value;

    resposta.push(resposta);
    resposta.push(A);
    resposta.push(B);
    resposta.push(C);
    resposta.push(D);
    resposta.push(bingo);


    console.log(resposta);
    clear();
}

function clear() {
    document.querySelector(".resposta").value = "";
    document.querySelector(".A").value = "";
    document.querySelector(".B").value = "";
    document.querySelector(".C").value = "";
    document.querySelector(".D").value = "";
    document.querySelector(".respostaCerta").value = "";
}