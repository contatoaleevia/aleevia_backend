namespace Application.DTOs.Email;

public static class WelcomeEmailTemplate
{
    public static string GetSubject() => "Seu cadastro na Aleevia foi concluído! 🎉";

    public static string GetBody(string verificationLink) => @$"
        <!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>
        <html xmlns='http://www.w3.org/1999/xhtml'>
        <head>
            <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
            <meta name='viewport' content='width=device-width, initial-scale=1.0'/>
            <title>Verificação de Email</title>
            <!--[if mso]>
            <style type='text/css'>
            body, table, td {{font-family: Arial, Helvetica, sans-serif !important;}}
            </style>
            <![endif]-->
            <style type='text/css'>
                @media only screen and (max-width: 600px) {{
                    .email-wrapper {{
                        width: 100% !important;
                    }}
                    .button {{
                        width: 100% !important;
                    }}
                }}
                
                /* Import Nunito font */
                @import url('https://fonts.googleapis.com/css2?family=Nunito:wght@400;700&display=swap');
                
                body {{
                    margin: 0;
                    padding: 0;
                    background-color: #F2F2F7;
                    -webkit-text-size-adjust: 100%;
                    -ms-text-size-adjust: 100%;
                }}
                
                img {{
                    border: 0;
                    height: auto;
                    line-height: 100%;
                    outline: none;
                    text-decoration: none;
                    -ms-interpolation-mode: bicubic;
                }}
                
                table {{
                    border-collapse: collapse !important;
                }}
                
                .email-wrapper {{
                    width: 100%;
                    max-width: 600px;
                    margin: 0 auto;
                }}
                
                .title {{
                    font-family: 'Nunito', Arial, sans-serif;
                    font-weight: 700;
                    font-size: 32px;
                    line-height: 1.4;
                    letter-spacing: 0px;
                    text-align: center;
                    color: #333333;
                    margin: 20px 0;
                }}
                
                .content {{
                    font-family: Arial, sans-serif;
                    font-size: 16px;
                    line-height: 1.5;
                    color: #666666;
                }}
                
                .button {{
                    background-color: #0052FF;
                    border-radius: 8px;
                    color: #ffffff!important;
                    display: inline-block;
                    font-family: Arial, sans-serif;
                    font-size: 16px;
                    font-weight: 500;
                    line-height: 50px;
                    text-align: center;
                    text-decoration: none;
                    width: 200px;
                    -webkit-text-size-adjust: none;
                }}
                
                .social-links {{
                    margin: 30px 0;
                }}
                
                .social-links a {{
                    color: #0052FF;
                    text-decoration: none;
                    font-family: Arial, sans-serif;
                }}
                
                .footer {{
                    font-family: Arial, sans-serif;
                    font-size: 12px;
                    color: #999999;
                    text-align: left;
                }}
            </style>
        </head>
        <body style='margin: 0; padding: 0; background-color: #F2F2F7;'>
            <table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#F2F2F7'>
                <tr>
                    <td>
                        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600' class='email-wrapper'>
                            <tr>
                                <td style='padding: 40px 0 60px 50px;'>
                                    <img src='https://jssbucket.s3.amazonaws.com/healthai/healthai/20250331_183033_b156b5a5.png' alt='Aleevia' width='240' style='display: block;' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h1 class='title'>Seu cadastro na Aleevia<br>foi concluído! 🎉</h1>
                                </td>
                            </tr>
                            <tr>
                                <td class='content' style='padding: 20px 40px; text-align: center;'>
                                    <p>Seu cadastro na Aleevia foi realizado com sucesso! Agora você já pode acessar a plataforma e aproveitar todas as nossas funcionalidades para cuidar da sua saúde com mais facilidade.</p>
                                    <p>Acesse sua conta aqui:</p>
                                    <p style='margin: 30px 0;'>
                                        <a href='{verificationLink}' class='button'>Acessar conta</a>
                                    </p>
                                    <p>Obrigada por utilizar a Aleevia, sua saúde na palma de suas mãos</p>
                                    <p>Equipe Aleevia 💙</p>
                                </td>
                            </tr>
                            <tr>
                                <td align='center' class='social-links'>
                                    <a href='https://aleevia.com' style='color: #0052FF; text-decoration: none; font-family: Arial, sans-serif; margin-right: 20px;'>aleevia.com</a>
                                    <span style='color: #666666; margin: 0 5px;'>|</span>
                                    <a href='https://www.instagram.com/aleevia.ai?igsh=dzVrbGc2OHhtMHEw' style='margin: 0 10px;'>
                                        <img src='https://jssbucket.s3.amazonaws.com/healthai/healthia/20250407_104225_0821c413.png' alt='Instagram' width='24' height='24' style='display: inline-block; vertical-align: middle;' />
                                    </a>
                                    <a href='https://linkedin.com/company/aleevia' style='margin: 0 10px;'>
                                        <img src='https://jssbucket.s3.amazonaws.com/healthai/healthia/20250407_104225_a02795b9.png' alt='LinkedIn' width='24' height='24' style='display: inline-block; vertical-align: middle;' />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td class='footer' style='padding: 20px 40px;'>
                                    <p>Se você não se inscreveu nesta conta, pode ignorar este e-mail e a conta será excluída.</p>
                                    <p>© 2024 Empresa. Todos os direitos reservados.</p>
                                    <p style='text-align: center;'>
                                        <a href='{verificationLink}' style='color: #0052FF; text-decoration: none;'>Ver e-mail no browser</a>
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </body>
        </html>";
} 