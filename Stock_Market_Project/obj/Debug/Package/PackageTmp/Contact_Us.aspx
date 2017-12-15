<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="Contact_Us.aspx.cs" Inherits="Stock_Market_Project.Contact_Us" EnableEventValidation="false" ValidateRequest="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="Placeholder1" runat="server">
</asp:Content>
<asp:Content ID="Contenttemp" ContentPlaceHolderID="ContentPlaceHoldertemp" runat="server">
    <div id="contact-section">
        <div class="container" >
            <div class="row main-top-margin text-center">
                <div class="col-md-8 col-md-offset-2 col-sm-10 col-sm-offset-1" data-scrollreveal="enter top and move 100px, wait 0.5s">
                    <h1>Contact Us</h1>
                    <h4>
                       Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                       
                    </h4>
                </div>
            </div>
            <!-- ./ Main Heading-->
            <div class="row">
                <div class="col-md-12  col-sm-12 ">
                    <div class="col-md-6  col-sm-12" data-scrollreveal="enter left and move 100px, wait 0.8s">
                        <h3><i class="fa fa-tint"></i> Reach Us Here</h3>
                        <hr />
                        <p>
                        103, New Street,<br />
                            New York, USA.<br />                          
                        Call: +23-00-89-009<br />
                        Email: demo@yourdomain.com<br />
                            </p>
                        <h3> Social Presence</h3>
                        <a href="#"><i class="fa fa-facebook-square fa-3x color-facebook"></i></a>
                        <a href="#"><i class="fa fa-twitter-square fa-3x color-twitter"></i></a>
                        <a href="#"><i class="fa fa-google-plus-square fa-3x color-google-plus"></i></a>
                        <a href="#"><i class="fa fa-linkedin-square fa-3x color-linkedin"></i></a>
                        <a href="#"><i class="fa fa-pinterest-square fa-3x color-pinterest"></i></a>
                    </div>
                    <div class="col-md-6  col-sm-12" data-scrollreveal="enter right and move 100px, wait 0.8s">
                        <h3>Need Help ? Write Us. </h3>
                        <hr />
                        <form>
                             <div class="row">
                                <div class="col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <input type="text" class="form-control" required="required" placeholder="Name">
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <input type="text" class="form-control" required="required" placeholder="Email address" runat="server" id="emailContact">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <textarea name="message" ID="msg" required="required" class="form-control" rows="8"  placeholder="Message" runat="server"></textarea>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="SendRequest_Btn" class="btn btn-primary" Text="Send Request"  runat="server"  OnClick="on_Click_SendRequest_Button"/>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                    
                </div>
            </div>
             <!-- ./ Row Content-->
        </div>
    </div>  
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder2" runat="server">
    

</asp:Content>
