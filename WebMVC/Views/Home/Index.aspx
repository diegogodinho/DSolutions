<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebMVC.Models.PesquisaPrincipalModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#Cidades").val('selecione');
            $("#Bairros").val('selecione');
            $("#Cidades").change(function () {
                var selectedItem = $(this).val();
                $("#Bairros").html('');
                $("#Bairros").append($('<option></option>').val('selecione').html('Selecione...'));
                $("#Bairros").val('selecione');
                if (selectedItem != 'selecione') {
                    $.ajax({
                        type: "GET",
                        url: "/Bairro/getBairros/" + selectedItem,
                        success: function (data) {
                            $("#Bairros").html('');
                            $.each(data, function (id, option) {
                                $("#Bairros").append($('<option></option>').val(option.Value).html(option.Text));
                            });
                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                            alert('Falhar ao buscar os bairros, tente novamente! Obrigado.');
                        }
                    });
                }
            });
        });
    </script>
    <div id="slider">
        <ul class="rslides">
            <li>
                <img src="../../img/slider-1.jpg" alt="">
                <div class="rslides-content">
                    <h2>
                        Belvedere, BH</h2>
                    <p>
                        Lugar calmo repleto de tranquilidade e bem estar. Próximo ao centro, desfrute de
                        toda a qualidade da zona sul.
                    </p>
                    <%-- <p>
                        This cosy home has <b>8 bedrooms and 6 bathrooms</b>. Aenean ultricies mi vitae
                        est. Donec eu quam egestas semper. <a href="property.html">Read More</a></p>--%>
                </div>
            </li>
            <li>
                <img src="../../img/slider-2.jpg" alt="">
                <div class="rslides-content">
                    <h2>
                        Funcionários, BH</h2>
                    <p>
                        Nulla sagittis convallis arcu. Mauris dictum libero photo credit id justo. Fusce
                        in est. Sed nec diam. Habitant morbi tristique. <a href="property.html">Read More</a></p>
                </div>
            </li>
            <li>
                <img src="../../img/slider-3.jpg" alt="">
                <div class="rslides-content">
                    <h2>
                        Camargos, Contagem</h2>
                    <p>
                        Sagittis convallis arcu. Mauris dictum libero photo credit id justo. Sed nec diam.
                        Pellentesque habitant morbi tristique. Fusce in est. <a href="property.html">Read More</a></p>
                </div>
            </li>
        </ul>
    </div>
    <!-- /slider -->
    <!-- search widget -->
    <div class="search">
        <div class="search-inner">
            <h3>
                <span>Encontre seu lar</span></h3>
            <form action="browse.html" id="form-availability" method="post">
            <div class="one">
                <label>
                    Cidade
                </label>
                <%= Html.DropDownListFor(r=> r.Cidades,Model.Cidades) %>
                <%--<select name="location">
                    <option value="selecione">Selecione...</option>
                    <option value="newyork">New York (6)</option>
                    <option value="boston">Boston (9)</option>
                </select>--%>
            </div>
            <div class="one">
                <label>
                    Bairro</label>
                    <%= Html.DropDownListFor(r=> r.Bairros,Model.Bairros) %>
                <%--<select name="type">
                    <option value="selecione">Selecione...</option>
                    <option value="apartment">Apartment</option>
                    <option value="condo">Condo</option>
                    <option value="villa">Villa</option>
                    <option value="castle">Huge Castle</option>
                </select>--%>
            </div>
            <div class="one">
                <label>
                    Tipo</label>
                <select name="type">
                    <option value="selecione">Selecione...</option>
                    <option value="apartment">Apartment</option>
                    <option value="condo">Condo</option>
                    <option value="villa">Villa</option>
                    <option value="castle">Huge Castle</option>
                </select>
            </div>
            <div class="clear">
            </div>
            <div class="one_half">
                <label>
                    Quartos</label>
                <select name="bedrooms">
                    <option value="selecione">Selecione...</option>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4+</option>
                </select>
            </div>
            <%--<div class="one_half last">
                <label>
                    Banheiros</label>
                <select name="bathrooms">
                    <option value="selecione">Selecione...</option>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3+</option>
                </select>
            </div>--%>
            <%--  <div class="clear">
            </div>--%>
            <%--<div class="one_half last">
                <label>
                    Preço mínimo</label>
                <select name="price-min">
                    <option value="selecione">Selecione...</option>
                    <option value="25k">R$25.000</option>
                    <option value="50k">R$50.000</option>
                    <option value="75k">R$75.000</option>
                    <option value="100k">R$100.000</option>
                    <option value="150k">R$150.000</option>
                    <option value="200k">R$200.000</option>
                    <option value="300k">R$300.000</option>
                    <option value="400k">R$400.000</option>
                    <option value="500k">R$500.000</option>
                    <option value="750k">R$750.000</option>
                </select>
            </div>--%>
            <div class="one_half last">
                <label>
                    Faixa de Preço</label>
                <select name="price-max">
                    <option value="selecione">Selecione...</option>
                    <option value="50k">R$0 a R$100.000</option>
                    <option value="75k">R$75.000</option>
                    <option value="100k">R$100.000</option>
                    <option value="150k">R$150.000</option>
                    <option value="200k">R$200.000</option>
                    <option value="300k">R$300.000</option>
                    <option value="400k">R$400.000</option>
                    <option value="500k">R$500.000</option>
                    <option value="750k">R$750.000</option>
                    <option value="1000k">R$1.000.000</option>
                </select>
            </div>
            <div class="clear">
            </div>
            <button type="submit" name="submit">
                Search</button>
            </form>
        </div>
        <!-- /search-inner -->
    </div>
    <!-- /search -->
    <h2 class="highlight">
        <span>Imóveis recomendados</span></h2>
    <ul class="listing">
        <li class="one_third"><a href="property.html">
            <img src="../../img/listing-1.jpg" alt="">
            <h3>
                West Milford, MA</h3>
            <span class="featured">Featured</span> <span class="price">R$379000</span>
            <ul class="listing-info">
                <li class="listing-info-beds">3 Beds</li>
                <li class="listing-info-baths">2 Baths</li>
                <li class="listing-info-area">3,775 ft<sup>2</sup></li>
            </ul>
        </a></li>
        <li class="one_third"><a href="property.html">
            <img src="../../img/listing-2.jpg" alt="">
            <h3>
                Belleville, NY</h3>
            <span class="price">R$189000</span>
            <ul class="listing-info">
                <li class="listing-info-beds">2 Beds</li>
                <li class="listing-info-baths">1 Baths</li>
                <li class="listing-info-area">1,375 ft<sup>2</sup></li>
            </ul>
        </a></li>
        <li class="one_third last"><a href="property.html">
            <img src="../../img/listing-3.jpg" alt="">
            <h3>
                North Caldwell, NY</h3>
            <span class="price">R$179000</span>
            <ul class="listing-info">
                <li class="listing-info-beds">2 Beds</li>
                <li class="listing-info-baths">2 Baths</li>
                <li class="listing-info-area">2,050 ft<sup>2</sup></li>
            </ul>
        </a></li>
        <li class="one_third"><a href="property.html">
            <img src="../../img/listing-3.jpg" alt="">
            <h3>
                Maplewood, MA</h3>
            <span class="price">R$379000</span>
            <ul class="listing-info">
                <li class="listing-info-beds">3 Beds</li>
                <li class="listing-info-baths">1 Baths</li>
                <li class="listing-info-area">2,175 ft<sup>2</sup></li>
            </ul>
        </a></li>
        <li class="one_third"><a href="property.html">
            <img src="../../img/listing-1.jpg" alt="">
            <h3>
                North Arlington, MA</h3>
            <span class="price">R$236000</span>
            <ul class="listing-info">
                <li class="listing-info-beds">4 Beds</li>
                <li class="listing-info-baths">1 Baths</li>
                <li class="listing-info-area">3,100 ft<sup>2</sup></li>
            </ul>
        </a></li>
        <li class="one_third last"><a href="property.html">
            <img src="../../img/listing-2.jpg" alt="">
            <h3>
                Wilmington, MA</h3>
            <span class="price">R$119000</span>
            <ul class="listing-info">
                <li class="listing-info-beds">2 Beds</li>
                <li class="listing-info-baths">1 Baths</li>
                <li class="listing-info-area">1,025 ft<sup>2</sup></li>
            </ul>
        </a></li>
    </ul>
    <!-- /listing -->
</asp:Content>
