<%@ Page Title="" Language="VB" MasterPageFile="~/basica.master" AutoEventWireup="false" CodeFile="register.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
      <asp:FormView ID="fvRegistro" runat="server" DataKeyNames="id" DataSourceID="sqlDsRegistro">
                            <InsertItemTemplate>
                                <div>
                                    <div>
                                        <asp:Label ID="lbLogin" runat="server" Text="Label">Login (*):</asp:Label>
                                        <asp:TextBox ID="tbLogin" runat="server" Text='<%# Bind("login") %>' style="max-width: 150px;" />
                                        <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ControlToValidate="tbLogin" ErrorMessage=" Dato obligatorio"
                                            Display="Dynamic" style="color:red; font-size: 1.2em; padding: 0.3em;" />
                                        <asp:RegularExpressionValidator ID="revLogin" runat="server" Display="Dynamic" ControlToValidate="tbLogin" ErrorMessage="Login de usuario entre 6 y 15 caracteres"
                                            ValidationExpression="\w{6,15}" style="color:red; font-size: 1.2em; padding: 0.3em;"
                                        />
                                        <asp:CustomValidator ID="cvLoginLibre" runat="server" ControlToValidate="tbLogin" Display="Dynamic" ErrorMessage="El login del usuario ya está en uso. Pruebe otro."
                                            ClientValidationFunction="validarloginusuario" ValidateEmptyText="false"  style="color:red; font-size: 1.2em; padding: 0.3em;"
                                        />
                                    </div>
                                    <div></div>
                                </div>

                                <div>
                                    <div >
                                        <asp:Label ID="lbPassword1" runat="server" Text="Label">Password (*):</asp:Label>
                                        <asp:TextBox ID="tbPassword1" runat="server" Text='<%# Bind("password") %>' TextMode="Password" style="max-width: 150px;" />
                                        <asp:RequiredFieldValidator ID="rfvPassword1" runat="server" ControlToValidate="tbPassword1" ErrorMessage="Dato obligatorio"
                                            Display="Dynamic" style="color:red; font-size: 1.2em; padding: 0.3em;" />
                                        <asp:RegularExpressionValidator ID="revPassword1" runat="server" Display="Dynamic" ControlToValidate="tbPassword1" ErrorMessage="Contraseña entre 6 y 15 caracteres"
                                            ValidationExpression="\w{6,15}" style="color:red; font-size: 1.2em; padding: 0.3em;"
                                        />
                                    </div>
                                </div>
                                <div>
                                    <div >
                                        <asp:Label ID="lbPassword2" runat="server" Text="Label">Password. Confirmación (*):</asp:Label>
                                        <asp:TextBox ID="tbPassword2" runat="server" TextMode="Password" style="max-width: 150px;" />
                                        <asp:RequiredFieldValidator ID="rfvPassword2" runat="server" ControlToValidate="tbPassword2" ErrorMessage="Dato obligatorio"
                                            Display="Dynamic" style="color:red; font-size: 1.2em; padding: 0.3em;" />
                                        <asp:RegularExpressionValidator ID="revPassword2" runat="server" Display="Dynamic" ControlToValidate="tbPassword2" ErrorMessage="Contraseña entre 6 y 15 caracteres"
                                            ValidationExpression="\w{6,15}" style="color:red; font-size: 1.2em; padding: 0.3em;" />
                                        <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToValidate="tbPassword2"
                                            ControlToCompare="tbPassword1" Display="Dynamic" Operator="Equal" Type="String" style="margin-left:30px; color:red; font-size: 1.2em; padding: 0.3em;"></asp:CompareValidator>
                                    </div>
                                </div>
                                <div>
                                    <div >
                                        <asp:Label ID="lbNombre" runat="server" Text="Label"> Nombre (*):</asp:Label>
                                        <asp:TextBox ID="tbNombre" runat="server" Text='<%# Bind("nombre") %>' MaxLength="80" />                                   
                                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="tbNombre" ErrorMessage="Dato obligatorio" Display="Dynamic"
                                            style="color:red; font-size: 1.2em; padding: 1.2em;" />
                                    </div>
                                </div>
                                <div>
                                    <div >
                                        <asp:Label ID="lbEmail1" runat="server" Text="Label">Email (*):</asp:Label>
                                        <asp:TextBox ID="tbEmail1" runat="server" Text='<%# Bind("email") %>'  TextMode="email" MaxLength="128"  />
                                        <asp:RequiredFieldValidator ID="rfvEmail1" runat="server" ControlToValidate="tbEmail1" ErrorMessage="Dato obligatorio" Display="Dynamic"
                                            style="color:red; font-size:1.2em; padding: 0.3em;" />
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="Dynamic" ControlToValidate="tbEmail1" ErrorMessage="Solo correos iesoretania.es"
                                            ValidationExpression="\w+([-+.']\w+)*@+(\w+([.]))*iesoretania.es" style="color:red; font-size: 1.2em; padding: 0.3em;"
                                        />

                                    </div>
                                </div>
                                <div>
                                    <div >
                                        <asp:Label ID="lbEmail2" runat="server" Text="Label">Email. Confirmación (*):</asp:Label>
                                        <asp:TextBox ID="tbEmail2" runat="server" TextMode="email" MaxLength="256"  />                                    
                                        <asp:RequiredFieldValidator ID="rfvEmail2" runat="server" ControlToValidate="tbEmail2" ErrorMessage="Dato obligatorio" Display="Dynamic"
                                            style="color:red; font-size: 1.2em; padding: 0.3em;" />
                                        <asp:RegularExpressionValidator ID="reEmail2" runat="server" Display="Dynamic" ControlToValidate="tbEmail2" ErrorMessage="Solo correos iesoretania.es"
                                            ValidationExpression="\w+([-+.']\w+)*@+(\w+([.]))*iesoretania.es" style="color:red; font-size: 1.2em; padding: 0.3em;"
                                        />
                                        <asp:CompareValidator ID="cvEmail2" runat="server" ErrorMessage="las direcciones de correo no coinciden" ControlToValidate="tbEmail2"
                                            ControlToCompare="tbEmail1" Display="Dynamic" Operator="Equal" Type="String" style="color:red; font-size: 1.2em; padding: 0.3em;"></asp:CompareValidator>
                                    </div>
                                </div>
                                <div>
                                    <div >
                                        <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="insert" Text="Ok" /> &nbsp;
                                        <asp:Button ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"  PostBackUrl="~/Default.aspx" />
                                    </div>
                                </div>
                            </InsertItemTemplate>
                        </asp:FormView>
                        <asp:SqlDataSource ID="sqlDsRegistro" runat="server" ConnectionString="<%$ ConnectionStrings:oretubeCnx %>" 
                            DeleteCommand="delete Usuario where id = @id" 
                            InsertCommand="userRegistro_sp" InsertCommandType="StoredProcedure" >
                            <DeleteParameters>
                                <asp:Parameter Name="id" dbType="Guid" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="login" Type="String" />
                                <asp:Parameter Name="password" Type="String" />
                                <asp:Parameter Name="email" Type="String" />
                                <asp:Parameter Name="nombre" Type="String" />
                                <asp:Parameter Name="k" dbType="Guid" Direction="Output" />
                            </InsertParameters>
                        </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="barra" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="endContenido" Runat="Server">
</asp:Content>

