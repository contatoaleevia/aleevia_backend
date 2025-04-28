namespace Application.DTOs.Email;

public static class WelcomeEmailTemplate
{
    public static string GetSubject() => "Bem-vindo ao Aleevia!";

    public static string GetBody(string userName) => @$"
        <html>
            <body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>
                <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
                    <h1 style='color: #2c3e50;'>Bem-vindo ao Aleevia!</h1>
                    <p>Olá {userName},</p>
                    <p>Estamos muito felizes em ter você conosco! Sua conta foi criada com sucesso.</p>
                    <p>Você agora tem acesso a todas as funcionalidades da nossa plataforma.</p>
                    <p>Se precisar de ajuda ou tiver alguma dúvida, não hesite em nos contatar.</p>
                    <p style='margin-top: 30px;'>
                        Atenciosamente,<br>
                        Equipe Aleevia
                    </p>
                </div>
            </body>
        </html>";
} 