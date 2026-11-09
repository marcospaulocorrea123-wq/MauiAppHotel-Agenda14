# 🏨 MauiAppHotel — Sistema de Reserva e Cálculo de Diárias

---

## 🎯 Objetivo da Atividade

O **MauiAppHotel** foi desenvolvido como atividade prática da disciplina de **Programação Mobile / Desenvolvimento de Sistemas (Agenda 14)**. 

O foco principal do projeto foi a **evolução arquitetural** da aplicação iniciada na Agenda 13, transformando interfaces visuais estáticas em um sistema dinâmico, confiável e orientado a dados, alicerçado nos conceitos fundamentais da **Programação Orientada a Objetos (POO)**:
* **Separação em Camadas:** Organização estruturada entre regras de domínio (`Models`) e apresentação visual (`Views`).
* **Classes de Domínio (`Suite` e `Hospedagem`):** Implementação de abstração, atributos com encapsulamento, instanciação dinâmica e agregação de objetos.
* **Comunicação entre Telas:** Compartilhamento de instâncias via `BindingContext` e navegação assíncrona com `NavigationPage`.
* **Identidade Visual Refinada:** Redesign completo para a paleta *Dark Noturna com acabamento Dourado Nobre*, garantindo consistência em todas as telas.

---

## 🤖 Uso da Inteligência Artificial no Desenvolvimento

Neste projeto, a **Inteligência Artificial (IA)** foi adotada de forma estratégica como **ferramenta de apoio ao desenvolvedor (Pair Programming / Copiloto)**, contribuindo diretamente nas seguintes etapas:

* **Diagnóstico e Resolução de Erros de Build:** Análise em tempo real de logs de compilação complexos (como erros `CS0266`, `CS1061` e exceções de runtime `XamlParseException`), identificando rapidamente divergências causadas por novas regras de tipos anuláveis (`DateTime?`) do .NET 10.
* **Modernização e Refatoração de Código:** Apoio na transição de componentes legados/obsoletos (como a substituição de `<Frame>` por `<Border>` e de chamadas síncronas de alertas por `DisplayAlertAsync`).
* **Resolução de Problemas de Renderização e Hit-Test:** Diagnóstico do comportamento do controle `Picker` no Windows, eliminando conflitos de camadas visuais que bloqueavam o clique e corrigindo cortes nas palavras.
* **Padronização Arquitetural e Documentação:** Apoio na estruturação lógica do fluxo de dados e elaboração da documentação técnica e deste guia no GitHub.

---

## 🛠️ Tecnologias e Ferramentas 

<p align="center">
  <img src="https://img.shields.io/badge/C%23-.NET%20MAUI-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
  <img src="https://img.shields.io/badge/.NET-MAUI-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
  <img src="https://img.shields.io/badge/Visual%20Studio-Community-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white"/>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Git-Version%20Control-F05032?style=for-the-badge&logo=git&logoColor=white"/>
  <img src="https://img.shields.io/badge/GitHub-Repositories-181717?style=for-the-badge&logo=github&logoColor=white"/>
  <img src="https://img.shields.io/badge/Notepad%2B%2B-Editor-90E59A?style=for-the-badge&logo=notepadplusplus&logoColor=black"/>
</p>
└── MauiProgram.cs                     # Ponto de entrada (builder) da aplicação

---

---

## 🚀 Como Utilizar o Aplicativo

1. **Seleção de Acomodação:**
   * Clique no seletor (*Picker*) para expandir e escolher entre *Suíte Super Luxo*, *Suíte Executiva* ou *Suíte Standard*.
2. **Definição de Hóspedes:**
   * Ajuste o número de adultos (mínimo 1) e crianças através dos botões *Stepper*.
3. **Seleção de Período (Check-in e Check-out):**
   * Escolha a data de entrada e de saída. O sistema recalcula automaticamente a data mínima de check-out para o dia seguinte ao check-in.
4. **Validações de Regra de Negócio:**
   * Ao clicar em **"Avançar para o Resumo"**, o aplicativo verifica:
     * Se uma acomodação foi selecionada.
     * Se a quantidade de hóspedes excede a **Capacidade Máxima** da suíte.
     * Se o check-out é estritamente posterior ao check-in.
5. **Tela de Resumo (`HospedagemContratada`):**
   * Exibe o recibo completo da simulação, listando os benefícios da suíte, hóspedes, diárias e o **Valor Total** monetário formatado.
6. **Tela Sobre o Hotel (`SobrePage`):**
   * Acessada pelo botão secundário, exibe a imagem de fachada do hotel em moldura retangular com cantos arredondados, versão e dados institucionais da disciplina.

---

## 📱 Apresentação das Telas do App

Abaixo estão ilustrados os 6 fluxos essenciais da aplicação:

<img width="2264" height="2112" alt="01" src="https://github.com/user-attachments/assets/9475f48c-8830-4911-ba58-70761e1e7f17" />


---

## ⚠️ Dificuldades Enfrentadas e Soluções Técnicas

Durante o desenvolvimento, desafios técnicos do ambiente multiplataforma foram enfrentados e solucionados:

1. **Tratamento de Datas Anuláveis no .NET 10 (`DateTime?` vs `DateTime`):**
   * *Desafio:* No .NET 10, o `DatePicker` adota tipos anuláveis (`DateTime?`), disparando erros `CS0266` e `CS1061` ao invocar métodos como `.AddDays()` ou na atribuição ao modelo.
   * *Solução:* Utilização do operador de coalescência nula (`?? DateTime.Now`) e conversões seguras no C#.

2. **Hit-Test e Renderização no `Picker` de Acomodação:**
   * *Desafio:* No Windows, o `Picker` não acionava a lista suspensa ao ser englobado por certos contêineres e cortava visualmente a base das palavras.
   * *Solução:* Remoção de sobreposições opacas, aumento de altura (`HeightRequest="60"`) e centralização vertical (`VerticalTextAlignment="Center"`).

3. **Substituição de Componentes Obsoletos:**
   * *Desafio:* Emissão de avisos `XLS1111` recomendando descontinuar o controle `Frame`.
   * *Solução:* Refatoração visual completa adotando `<Border>` com contornos vetoriais `<RoundRectangle>`.

4. **Correção de Rotas no `AppShell`:**
   * *Desafio:* A substituição de `Sobre.cs` por `SobrePage.xaml` gerou erro em tempo de execução (`XamlParseException`) devido a referências antigas no shell.
   * *Solução:* Atualização do `DataTemplate` e das rotas de navegação no `AppShell.xaml`.

---

## 🏁 Conclusão

O desenvolvimento do **MauiAppHotel** comprovou a relevância prática dos pilares da **Orientação a Objetos** em aplicações mobile contemporâneas. 

A transição de interfaces isoladas para um modelo orientado a domínio viabilizou reaproveitamento de código, encapsulamento de regras de negócio e maior robustez contra entradas inválidas. Adicionalmente, a experiência reforçou como a combinação entre **engenharia de software sólida** e o uso guiado de **Inteligência Artificial** acelera a resolução de bugs e eleva a qualidade do produto final.

https://github.com/marcospaulocorrea123-wq/MauiAppHotel-Agenda14.git
