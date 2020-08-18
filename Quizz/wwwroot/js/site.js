

function Validation() {
    let perguntas = document.querySelector("#PgtQtd").textContent;
    if (perguntas == "10") {
        let span = document.querySelector("#limite");
        span.innerHTML = "Quizz Cheio!";
        Object.freeze(span);
    }
}
