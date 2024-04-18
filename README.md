![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
# Descrição
Projeto para categorizar negociação.
Foi criada uma aplicação do tipo Console para ler uma arquivo de entrada chamado `input.txt` e gerar um arquivo de saída chamado `output.txt`.
O formato do arquivo `input.txt` deve seguir o seguinte padrão:
```
12/11/2020
4
2000000 Private 12/29/2025
400000 Public 07/01/2020
5000000 Public 01/02/2024
3000000 Public 10/26/2023
```
Onde: 
- na primeira linha há a data de referência do arquivo, no formato `MM/DD/YYYY`;
- na segunda linha há a quantidade de negociações (N) no arquivo;
- nas N linhas seguintes há as negociações, no formato: `valor` `setor do cliente` `data do próximo vencimento`
> Obs: As datas sempre no formato `MM/DD/YYYY` e os valores sem casas decimais, ou seja, $1.000.000,00 = 1000000

## Tecnologia
- .Net Core 8.0
- Xunit

## Design Patterns
- Factory Method
- OCP (Open/Closed Principle)

## Como adicionar novas Categorias
Todas as alterações deverão ser feitas no projeto `DevRisk.Domain`
1. Será necessário incluir o novo atributo a interface `ITrade` e atualizar todas as classes que a implementam;
2. Adicionar a nova classe `PEP.cs` que implementa a interface `ITrade`;
3. Adicionar ao DTO `TradeDto` o novo atributo `IsPoliticallyExposed`;
4. Na factory `TradeFactory` adicionar a regra para verificar se a negociação é do tipo PEP.
