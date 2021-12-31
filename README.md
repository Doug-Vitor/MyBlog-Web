<h1 align="center">Meu blog (cliente)</h1>
<h4 align="center">Aplicação responsável por gerenciar e abstrair as ações de um blog visando sua comunicação com seus colegas. Projeto cliente da API do MyBlog (confira <a href="https://github.com/Doug-Vitor/MyBlog-Api/">aqui</a>).</h3>

<br/>
<p>:warning: É obrigatório a utilização da <a href="https://github.com/Doug-Vitor/MyBlog-Api/">API do MyBlog</a> antes da utilização deste projeto. Certifique-se de ler os requisitos deste projeto e do projeto citado antes de testar.<p>
<p>:warning: Este projeto está sujeito a atualizações.<p>

<br/>
<h3>:computer: Tecnologias utilizadas:</h3>
<h4>
 <ul>
  <li>DotNET 6.0</li>
  </ul>
</h4>

<br/>
<h3>:wrench: Quer rodar o projeto? Siga os passos:</h3>
<h4>
 <ul><li>É necessário instalar o Visual Studio 2022.</li></ul>
 
 <br/>
 <ol>
  <li>Faça o download ou clone o projeto.</li>
  <li>Faça o download e siga os passos do projeto da <a href="https://github.com/Doug-Vitor/MyBlog-Api">API do MyBlog</a>.</li>
  <li>Abra o arquivo de solução chamado MyBlog.sln</li>
  <li>No arquivo appsettings.json (projeto MyBlog.Web), nos objetos "ApiCoreActionsRoutingConfigurations" e "ApiAuthenticationRoutingConfigurations", altere a porta (números presentes no valor de BasePath) para o seu localhost. É necessário executar a <a href="https://github.com/Doug-Vitor/MyBlog-Api">API do MyBlog</a> para descobrir o endereço que aponta para seu localhost.</li>
  <li>Restaure os pacotes NuGet da solução:
   <ul>
    <p>Pelo CLI: <blockquote>dotnet restore</blockquote></p>
    <p>Pelo CLI do NuGet: <blockquote>nuget restore MyBlog.sln</blockquote></p>
   </ul>
  </li>
</h4>

<br/>
<h3>Referências:</h3>
<ul>
  <li>Manipular o DOM utilizando javascript: <a href="https://developer.mozilla.org/pt-BR/docs/Web/JavaScript">Clique aqui!</a></li>
  <li>Mostrar uma frase quando o ponteiro do mouse passa por cima de um botão: <a href="https://www.w3schools.com/css/css_tooltip.asp">Clique aqui!</a></li>
</ul>
