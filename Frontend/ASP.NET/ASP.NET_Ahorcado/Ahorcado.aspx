<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ahorcado.aspx.cs" Inherits="ASP.NET_Ahorcado._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <link rel="stylesheet" type="text/css" href="Content/Ahorcado/Ahorcado.css" />

        <div id="game-container">
            <h1>Combate de Palabras</h1>
            <div id="battle-scene">
                <div id="person" class="character">🧙</div>
                <div id="goblin" class="character">👺</div>
            </div>
            <div id="hearts">❤️❤️❤️❤️❤️❤️❤️</div>
            <div id="word-display"></div>
            <div id="alphabet"></div>
            <div id="message"></div>
            <button id="restart-btn" class="btn btn-primary" style="display: none;">Reiniciar Juego</button>
        </div>
        <canvas id="confetti-canvas"></canvas>

        <script src="https://cdn.jsdelivr.net/npm/canvas-confetti@1.5.1/dist/confetti.browser.min.js"></script>
        <script src="Scripts/Ahorcado/Ahorcado.js"></script>
    </main>

</asp:Content>
