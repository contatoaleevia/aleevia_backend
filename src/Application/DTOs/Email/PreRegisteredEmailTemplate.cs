namespace Application.DTOs.Email;

public static class PreRegisteredEmailTemplate
{
    public static string GetSubject() => "Suas credenciais de acesso à Aleevia 🎉";

    public static string GetBody(string document, string password, string accessLink) => @$"
        <!DOCTYPE html>
        <html>
        <head>
            <meta charset='UTF-8'>
            <title>Credenciais de Acesso</title>
            <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css'>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    line-height: 1.6;
                    color: #333;
                    margin: 0;
                    padding: 0;
                    background-color: #f5f5f5;
                }}
                .email-wrapper {{
                    width: 100%;
                    max-width: 600px;
                    margin: 0 auto;
                    padding: 20px;
                    box-sizing: border-box;
                }}
                .logo {{
                    width: 200px;
                    height: auto;
                    margin: 0 0 40px;
                    display: block;
                    padding-left: 50px;
                }}
                .container {{
                    background-color: #ffffff;
                    border-radius: 8px;
                    padding: 40px;
                    margin-top: 20px;
                    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                }}
                .button {{
                    display: block;
                    padding: 12px 24px;
                    background-color: #0066FF;
                    color: #ffffff !important;
                    text-decoration: none;
                    border-radius: 5px;
                    margin: 20px auto;
                    font-weight: bold;
                    width: fit-content;
                }}
                .footer {{
                    margin-top: 30px;
                    font-size: 12px;
                    color: #666;
                }}
                .social-links {{
                    margin-top: 20px;
                    display: flex;
                    justify-content: center;
                    align-items: center;
                    gap: 15px;
                }}
                .social-links a {{
                    text-decoration: none;
                    color: #F2F2F7;
                    display: flex;
                    align-items: center;
                }}
                .social-links i {{
                    font-size: 20px;
                    margin-right: 5px;
                }}
                .divider {{
                    color: #666;
                    margin: 0 5px;
                }}
                .small-text {{
                    font-size: 11px;
                    color: #666;
                    margin-top: 20px;
                    border-top: 1px solid #eee;
                    padding-top: 20px;
                }}
                .small-text p {{
                    text-align: left;
                    margin: 5px 0;
                }}
                h1 {{
                    font-size: 24px;
                    margin-bottom: 20px;
                    text-align: center;
                    color: #333;
                }}
                p {{
                    color: #666;
                    margin: 10px 0;
                    text-align: center;
                }}
                .main-text {{
                    text-align: center;
                }}
                .team-signature {{
                    text-align: center;
                    margin: 20px 0;
                }}
                .blue-heart {{
                    color: #0066FF;
                }}
                .credentials-box {{
                    background-color: #f8f9fa;
                    border: 1px solid #dee2e6;
                    border-radius: 5px;
                    padding: 15px;
                    margin: 20px 0;
                    text-align: left;
                }}
                .credentials-box p {{
                    text-align: left;
                    margin: 5px 0;
                    color: #333;
                }}
                .warning-text {{
                    color: #dc3545;
                    font-weight: bold;
                    margin: 15px 0;
                }}
            </style>
        </head>
        <body>
            <div class='email-wrapper'>
                <img src='https://jssbucket.s3.amazonaws.com/healthai/healthai/20250331_183033_b156b5a5.png' alt='Aleevia' class='logo'>
                
                <div class='container'>
                    <h1>Suas credenciais de acesso<br>à Aleevia 🎉</h1>
                    
                    <p class='main-text'>Seu cadastro na Aleevia foi realizado com sucesso! Abaixo estão suas credenciais de acesso:</p>
                    
                    <div class='credentials-box'>
                        <p><strong>Documento:</strong> {document}</p>
                        <p><strong>Senha temporária:</strong> {password}</p>
                    </div>

                    <p class='warning-text'>⚠️ Por segurança, recomendamos que você altere sua senha após o primeiro acesso.</p>
                    
                    <p class='main-text'>Clique no botão abaixo para acessar sua conta:</p>
                    
                    <a href='{accessLink}' class='button'>Acessar conta</a>
                    
                    <div class='team-signature'>
                        <p>Obrigada por utilizar a Aleevia, sua saúde na palma de suas mãos</p>
                        <p>Equipe Aleevia 💙</p>
                    </div>
                    
                    <table width='100%' cellpadding='0' cellspacing='0' border='0' style='margin-top: 20px;'>
                        <tr>
                            <td align='center'>
                                <table cellpadding='0' cellspacing='0' border='0'>
                                    <tr>
                                        <td><a href='https://aleevia.com' style='color: #0050EF; text-decoration: none;'>aleevia.com</a></td>
                                        <td style='padding: 0 5px;'>|</td>
                                        <td><a href='https://facebook.com/aleevia' style='color: #0050EF; text-decoration: none;'>Facebook</a></td>
                                        <td style='padding: 0 5px;'>|</td>
                                        <td><a href='https://instagram.com/aleevia' style='color: #0050EF; text-decoration: none;'>Instagram</a></td>
                                        <td style='padding: 0 5px;'>|</td>
                                        <td><a href='https://linkedin.com/company/aleevia' style='color: #0050EF; text-decoration: none;'>LinkedIn</a></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    
                    <div class='small-text'>
                        <p>Se você não solicitou este acesso, por favor ignore este e-mail e entre em contato com nosso suporte.</p>
                        <p>© 2024 Empresa. Todos os direitos reservados.</p>
                        <p style='text-align: center; color: #0050EF;'><a href='{accessLink}'>Ver e-mail no browser</a></p>
                    </div>
                </div>
            </div>
        </body>
        </html>";
} 