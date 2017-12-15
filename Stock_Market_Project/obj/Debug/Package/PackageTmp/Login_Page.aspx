<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="Login_Page.aspx.cs" Inherits="Stock_Market_Project.Login_Page" EnableEventValidation="false" ValidateRequest="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="Placeholder1" runat="server">
      
       
   
        <input type="text" class="form-control"  placeholder="E_mail"   id="mailLogin_txt" runat="server" style="margin-top:15px ; margin-bottom:3px ; width:265px ; margin-left:-34px" validationgroup="login">
             <asp:Label  id="Block_msg1" Text="Your Account Has Blocked Contact with Admin"   style="margin-top:-2px ; margin-left:-33px ; font-size:small; color:lawngreen ; visibility:hidden " runat="server"></asp:Label>
     <asp:Label id="Block_msg" Text="Your Account Has Blocked Contact with Admin" Visible="false" style="margin-top:-2px  ; margin-left:-344px ; font-size:small; color:lawngreen" runat="server"></asp:Label>
     
        <%--<label style="color:white ; margin-top:-50px ; margin-left:10px" >Password </label>--%>
        <input type="password" class="form-control"  placeholder="Password" id="passLogin_txt" runat="server" style="margin:-55px 0px 0px 237px ; width:265px" validationgroup="login" >
       
    
    <asp:Button ID="forget_btn" Text="Forgot my Password?" runat="server" BorderStyle="None" style=" height:15px;font-size:x-small; margin-left:282px ; color:white" Font-Bold="True" BorderWidth="0" ForeColor="White" BackColor="#2F11C4" OnClick="on_Click_Forgot_Btn" />
        <%--<asp:TextBox ID="Pass_txt" runat="server" Width="170px" TextMode="Password" ></asp:TextBox>--%>

        <asp:Button ID="login_btn" class="btn btn-primary" Text="Log In" style="margin:-53px 3px 0px 107px ; width:93px" runat="server"  OnClick="on_Click_Login_Button" ValidationGroup="login"/>
   <asp:Button ID="d" class="btn btn-primary" Text="Contact Us" style="margin-left:3px;margin-top:-52px ; width:96px" runat="server" OnClick="on_Click_Contact_Us_Button" ValidationGroup="contact" />

</asp:Content>

<asp:Content ID="Contenttemp" ContentPlaceHolderID="ContentPlaceHoldertemp" runat="server">
    <div id="header-section">
        <div class="container">
            <div class="row centered">
                <div class="col-md-8 col-md-offset-2 col-sm-8 col-sm-offset-2">
                    <h1> 
                        <br />
                        <div style="letter-spacing:20px ; font-weight:bolder"><strong>STOCK MARKET  </strong></div>
                    </h1>
                    <h2>Explore It</h2>
                     <br />
                  <a href="#registeration-section">  <i class="fa fa-angle-double-down fa-5x down-icon" style="margin-left:-5%"></i> </a>
                </div>
            </div>
          
        </div>
    
       
    </div>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder2" runat="server">
     <asp:RegularExpressionValidator   ID="RevEmail" runat="server" ErrorMessage="Incorrect E_mail Format" ValidateRequestMode="Inherit" ControlToValidate="email_txt" ViewStateMode="Inherit" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Visible="True" validationgroup="signup"></asp:RegularExpressionValidator> 
    <asp:RegularExpressionValidator ID="revpass" runat="server" ErrorMessage="Choose at  least 6 character with characters,numbers,1 upper case letter and special characters." ValidationExpression="(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$" ControlToValidate="pass_txt" Visible="True" validationgroup="signup"></asp:RegularExpressionValidator>
    <asp:CompareValidator ID="ComparePassword" runat="server" ErrorMessage="Password dont match" ControlToCompare="pass_txt" ControlToValidate="pass1_txt" Visible="True" validationgroup="signup"></asp:CompareValidator>
     <asp:RegularExpressionValidator   ID="RegExp_FName" runat="server" ErrorMessage="Incorrect First_Name Format" ValidateRequestMode="Inherit" ControlToValidate="fname_txt" ViewStateMode="Inherit" ValidationExpression="^[A-Za-z.\s_-]+$" Visible="True" validationgroup="signup"></asp:RegularExpressionValidator> 
    <asp:RegularExpressionValidator   ID="RegExp_LName" runat="server" ErrorMessage="Incorrect Last_Name Format" ValidateRequestMode="Inherit" ControlToValidate="lname_txt" ViewStateMode="Inherit" ValidationExpression="^[A-Za-z.\s_-]+$" Visible="True" validationgroup="signup"></asp:RegularExpressionValidator> 
        <div id="Div1">
        <div class="container" >
            <div class="row main-top-margin text-center">
                <div class="col-md-8 col-md-offset-2 col-sm-10 col-sm-offset-1" data-scrollreveal="enter top and move 100px, wait 0.5s">
                    <h1>Sign Up</h1>
                    
                </div>
            </div>
            <!-- ./ Main Heading-->
            <div class="row">
                <div class="col-md-12  col-sm-12 ">
                    <div class="col-md-6  col-sm-12" data-scrollreveal="enter left and move 100px, wait 0.8s">
                      
                       
                      
                      
                    </div>
                    <div class="col-md-6  col-sm-12" data-scrollreveal="enter right and move 100px, wait 0.8s" >
                        <div>
                        <form >
                            <div class="row">
                                <div class="col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <asp:RequiredFieldValidator ID="ReqValFname" runat="server" ErrorMessage="*" ControlToValidate="fname_txt" validationgroup="signup" style="margin-left:-75% ; color:red "></asp:RequiredFieldValidator>
                                        <input type="text" class="form-control"  placeholder="First_Name" style="margin-left:-180%;margin-top:-20px" id="fname_txt" runat="server" >
                                        
                                        <br />
                                        <asp:RequiredFieldValidator ID="ReqValLname" runat="server" ErrorMessage="*" ControlToValidate="lname_txt" validationgroup="signup" style="margin-left:-75%  ;color:red "></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="ReqValSavings" runat="server" ErrorMessage="*" ControlToValidate="saving_txt" validationgroup="signup" style="margin-left:110%  ;color:red "></asp:RequiredFieldValidator>
                                        <input type="text" class="form-control"  placeholder="Last_Name" style="margin-left:-180% ; margin-top:-10%" id="lname_txt" runat="server">
                                        <br />
                                        <asp:RequiredFieldValidator ID="ReqValPass" runat="server" ErrorMessage="*" ControlToValidate="pass_txt" validationgroup="signup" style="margin-left:-75% ; color:red "></asp:RequiredFieldValidator>
                                        <input type="password" class="form-control"  placeholder="Password" style="margin-left:-180% ; margin-top:-10%" id="pass_txt" runat="server" >
                                    </div>
                              
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <div class="form-group">
                                       
                                         <asp:RequiredFieldValidator ID="ReqValemail" runat="server" ErrorMessage="*" ControlToValidate="email_txt" validationgroup="signup" style="margin-left:45%; color:red"></asp:RequiredFieldValidator>
                                         <input type="text" class="form-control"  placeholder="Email address" style="margin-left:-60%;margin-top:-20px" id="email_txt" runat="server" >
                                        <br />
                                        <asp:RequiredFieldValidator ID="ReqValBdate" runat="server" ErrorMessage="*" ControlToValidate="bdate_txt" validationgroup="signup" style="margin-left:45%; color:red"></asp:RequiredFieldValidator>
                                        <input type="date" class="form-control"  placeholder="Birth Date ex: 01-JAN-90" style="margin-left:-60% ; margin-top:-10%" id="bdate_txt" runat="server"  >
                                          <br />
                                        <asp:RequiredFieldValidator ID="ReqValRepass" runat="server" ErrorMessage="*" ControlToValidate="pass1_txt" validationgroup="signup" style="margin-left:45%; color:red"></asp:RequiredFieldValidator>
                                        <input type="password" class="form-control"  placeholder="Retype_Password" style="margin-left:-60% ; margin-top:-10% " id="pass1_txt" runat="server">
                                    </div>
                                </div>
                             
                                <div class="col-md-6 col-sm-6">
                                    <div class="form-group">
                                    
                                                                                 <asp:FileUpload ID="FileUpload1" class="form-control" style="margin-left:-64%;margin-top:-89px" runat="server" />                                      

                                        
                                         <br />
                                                                                 <input type="text" class="form-control"  placeholder="savings ( in $ )" style="margin-left:-64%;margin-top:-89px" id="saving_txt" runat="server" >
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <asp:Label ID="savings_lbl"   runat="server" style="margin-left:-64%;margin-top:-89px ; color:red ; font-weight:bold" ></asp:Label>
                                    </div>
                                </div>

                                 <div class="col-md-6 col-sm-6">
                                    <div class="form-group">
                                      
                                         
                                         <div style=" margin-left:110px ; margin-top:-48% ; font-size:small ;color:red" ><asp:Label ID="message" runat="server" Text="" ></asp:Label></div>
                                        <br />
                                      
                                    </div>
                                </div>
                                           
                                 </div>  
                            
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                   
                                    <div class="form-group">
                                        
                                        <asp:Button ID="signUp_Btn" class="btn btn-primary" runat="server" style="margin-left:-15%" OnClick="on_Click_Sign_Up_Btn" Text="Sign Up" ValidationGroup="signup" />
                                        <asp:Label ID="signupmessage" runat="server" style="color:green"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                       </div>
                    
                </div>
            </div>
             <!-- ./ Row Content-->
        </div>
    </div>  
    <!--END CONTACT SECTION --> 

    <div style="margin-left:45% ; color:red" >
        <asp:ValidationSummary ID="valsum" runat="server" ShowValidationErrors="True" DisplayMode="BulletList" Font-Bold="True" validationgroup="signup" />
    </div>
</asp:Content>


