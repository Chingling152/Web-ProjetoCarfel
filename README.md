# Projeto Carfel (Checkpoint)

A empresa **Carfel** Automação em Gestão de Projetos, do ramo de desenvolvimento de sistemas voltados para gerência de projetos, 
deseja criar um novo site de apresentação para seu produto, o software: **Check Point**.  
  
Este software tem o objetivo de automatizar o processo de controle de frequência dos desenvolvedores do projeto.  

## Sobre o Site

O site de apresentação ~contem~ devia conter uma descrição geral sobre o produto 
(eu faço conteudo depois ;-;) , suas funcionalidades e uma descrição da desenvolvedora **Carfel** junto com suas informações 
de contato: endereço, telefone, etc.    
O site de apresentação contem as seguintes seções:  

- Home 
  - Menu de navegação 
  - Banner de apresentação 
- O Produto 
  - Descrição do produto  
  - Funcionalidades  
  - Telas do Produto (Não tem produto por agora)
  - Planos
    - Gratis
    - R$ 50,00/Mês
    - R$ 150,00/Mês
- Quem Somos 
  - Descrição da Carfel 
  - Imagens da equipe 
- Comentários dos Utilizadores do Sistema 
- Contato 
  - Nome da empresa 
  - Email 
  - Endereço 
  - Telefone
  - Mapa (utilizando mapa embutido do google) 
  - Formulário 
    - Nome 
    - Email 
    - Telefone 
    - Assunto 
    - Mensagem
- Perfil (Apenas para usuarios logados)
  - Fazer um comentario
  - Fazer Logoff
  - Aprovar Comentarios (Somente Administrador)
  - Ver Usuarios (Somente Administrador)
 
### Cadastro
O site, também tem uma área de cadastro de clientes. Neste, o cliente deverá informar:  
- Nome completo
- Data de Nascimento
- E-mail
- Senha
### Login
Ao informar os dados, o cliente será cadastrado no sistema. 
Haverá uma opção de realização de login para os clientes cadastrados.  
Nela, o usuário deverá informar **e-mail** e **senha** , caso a combinação exista no banco de dados, o cliente será autenticado.
Na **Pagina inicial** site institucional haverá uma sessão com os 4 comentários aprovados cadastrados no sistema e ordenados por 
data de criação (do mais atual para o mais antigo). 
### Comentario
Nos comentários deverão ser apresentados:
  - Foto de perfil (Por enquanto é gerada pelo sistema kkk)
  - Nome do usuário que comentou
  - Data do comentário
  - Texto do comentário
Caso o usuário esteja autenticado, haverá acima da sessão de comentários cadastrados uma área de cadastro de comentário. 
Nela, o usuário apenas informará o comentário que deseja adicionar e cadastra-lo. Ao ser cadastrado, este será enviado para aprovação.
### Aprovação de comentarios
A aprovação dos comentários deve ser realizadas **apenas pelo administrador** do sistema.
No sistema, só existe um administrador do sistema. Os dados que serão atribuídos à ele são:
  - E-mail : admin@carfel.com
  - Senha admin  
Haverá uma tela de aprovação de comentários. Nela, serão listados todos os comentários realizados que ainda não foram aprovados 
(ordenados por data de cadastro do mais novo para o mais antigo). 
Quando rejeitar: O comentário ficará marcado como rejeitado e será ocultado
Quando aprovar: O comentário será demarcado como aprovado, e assim, listado

***O Projeto ainda não foi finalizado por completo ....***
