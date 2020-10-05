# Projeto Dual API
 ## Projeto onde é criado 2 API's .Net Core, onde uma consumida pela outra

 ### A demanda
Você deverá criar duas API's uma com dois endpoints e outra com um endpoint:


    ### API 1

        1) Retorna taxa de juros

        Responde pelo path relativo "/taxaJuros" Retorna o juros de 1% ou 0,01 (fixo no código) Exemplo: /taxaJuros Resultado esperado: 0,01
    ### API 2

    #### Calcula Juros

        Responde pelo path relativo "/calculajuros"

        Ela faz um cálculo em memória, de juros compostos, conforme abaixo: Valor Final = Valor Inicial * (1 + juros) ^ Tempo

        Valor inicial é um decimal recebido como parâmetro. Valor do Juros deve ser consultado na API 1.
        Tempo é um inteiro, que representa meses, também recebido como parâmetro.

        ^ representa a operação de potência.

        Resultado final deve ser truncado (sem arredondamento) em duas casas decimais.

        Exemplo: /calculajuros?valorinicial=100&meses=5 Resultado esperado: 105,10

    #### Show me the code

        Este responde pelo path relativo /showmethecode Deverá retornar a url de onde encontra-se o fonte no github



 ## 🚀 Let's code! 🚀

  ## Projeto de Recrutamento da Squadra