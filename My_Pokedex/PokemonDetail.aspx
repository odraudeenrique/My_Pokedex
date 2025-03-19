<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PokemonDetail.aspx.cs" Inherits="My_Pokedex.PokemonDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #wholecard {
            width: 50%;
            height: 35%;
        }

        .card-img-top {
            height: 20rem;
            width: 20rem;
            object-fit: contain;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <main class="row">
        <div class="col"></div>
        <div class="col-8 .d-flex">

            <section class="card border-primar" id="wholeCard">
                <%if (Poke != null)
                    {%>
                <div class=" imageSection ">
                    <img src="<%:Poke.Url %>" alt="This is an image of a pokemon " class="card-img-top imageCard" />
                </div>
                <div class="card-body infoSection">
                    <div class="mb-3">
                        <h1 class="card-title"><%:Poke.Name %></h1>
                    </div>

                    <div class="d-flex flex-column p-3">
                        <div class="mb-3">
                            <h2 class="card-subtitle badge text-bg-primary  fs-4"><%:Poke.Number.ToString() %></h2>
                        </div>

                        <div>
                            <div class="mb-3 element">
                                <p class="card-text badge text-bg-success element"><%:Poke.Type.Description %></p>
                            </div>
                            <div class="mb-3 element" >
                                <p class="card-text  badge text-bg-dark  element"><%:Poke.Weakness.Description %></p>
                            </div>
                        </div>
                    </div>

                    <div class="mb-3">
                        <p class="card-text description fw-medium"><%:Poke.Description %></p>
                    </div>
                    <%}
                        else
                        {%>
                    <div class="mb-3">
                        <h1 class="card-title">An error has occurred</h1>
                    </div>
                    <div class="mb-3">
                        <h2 class="card-subtitle badge text-bg-primary fs-4">An error has occurred</h2>
                    </div>

                    <div class="mb-3">
                        <p class="card-text badge text-bg-success">An error has occurred</p>
                    </div>
                    <div class="mb-3">
                        <p class="card-text badge text-bg-dark">An error has occurred</p>
                    </div>

                    <div class="mb-3">
                        <p class="card-text description fw-medium">An error has occurred</p>
                    </div>
                </div>

                <%}%>
            </section>

            <section class="d-flex justify-content-center border-primar">
                <asp:Button ID="BtnUpdate" Text="Update Info" runat="server" CssClass="btn btn-secondary m-2" OnClick="BtnUpdate_Click" />
                <asp:Button ID="BtnDelete" Text="Delete Pokemon" runat="server" CssClass="btn btn-danger m-2" OnClick="BtnDelete_Click" />
            </section>

        </div>
        <div class="col"></div>

    </main>


</asp:Content>
