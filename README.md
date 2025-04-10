Voici le contenu complet du fichier README.md que vous pouvez copier et coller directement :
---
SmartEvent Platform
Pr�sentation
SmartEvent Platform est une application web con�ue pour g�rer des �v�nements. Elle permet aux utilisateurs de :
�	Consulter une liste d'�v�nements.
�	Voir les d�tails d'un �v�nement sp�cifique.
�	S'inscrire � des �v�nements.
�	Cr�er un profil utilisateur.
Le projet est divis� en deux parties :
1.	Backend : Une API REST d�velopp�e avec ASP.NET Core (.NET 8) pour g�rer les utilisateurs, les �v�nements et les inscriptions.
2.	Frontend : Une interface utilisateur d�velopp�e avec React pour interagir avec l'API.
---
Fonctionnalit�s
�	Gestion des utilisateurs : Cr�ez un profil utilisateur et connectez-vous.
�	Liste des �v�nements : Parcourez les �v�nements disponibles.
�	D�tails des �v�nements : Consultez les informations d�taill�es sur un �v�nement.
�	Inscription aux �v�nements : Inscrivez-vous � un �v�nement en un clic.
�	Interface utilisateur moderne : Une interface �l�gante et intuitive.
---
Installation
Pr�requis
�	.NET 8 SDK
�	Node.js (version 16 ou sup�rieure)
�	Un gestionnaire de packages comme npm ou yarn
�	SQL Server pour la base de donn�es
�tapes d'installation
1.	Clonez le d�p�t :
    git clone https://github.com/votre-repo/smartevent-platform.git
    cd smartevent-platform
2.	Configuration du backend :
�	Acc�dez au dossier du backend :
	git clone https://github.com/votre-repo/smartevent-platform.git
    cd smartevent-platform
�	Configurez la cha�ne de connexion � la base de donn�es dans appsettings.json :
 1. "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=SmartEventDB;Trusted_Connection=True;"
}
2�	Appliquez les migrations et mettez � jour la base de donn�es :
 -> dotnet ef database update
 �	Lancez le serveur backend :
 -> dotnet run
 3.	Configuration du frontend :
�	Acc�dez au dossier du frontend :
 -> cd frontend
�	Installez les d�pendances :
 -> npm install
 �	Lancez le serveur de d�veloppement :
 -> npm start 
 4.	Acc�dez � l'application :
�	Frontend : http://localhost:3000
�	Backend : https://localhost:7151
---
Utilisation
Cr�er un utilisateur
1.	Acc�dez � la page de cr�ation d'utilisateur.
2.	Remplissez les champs requis (nom, email, mot de passe).
3.	Cliquez sur "Cr�er le profil".
Consulter les �v�nements
1.	Acc�dez � la page des �v�nements.
2.	Parcourez la liste des �v�nements disponibles.
Voir les d�tails d'un �v�nement
1.	Cliquez sur un �v�nement dans la liste.
2.	Consultez les informations d�taill�es (nom, description, date, organisateur).
S'inscrire � un �v�nement
1.	Cliquez sur le bouton "Register" � c�t� d'un �v�nement.
2.	Confirmez votre inscription dans la bo�te de dialogue.
---
Questions fr�quentes            
1. Pourquoi ai-je une erreur CORS lors de l'acc�s � l'API ?
Assurez-vous que le backend est configur� pour autoriser les requ�tes provenant du frontend. V�rifiez la configuration CORS dans Program.cs :
                           
1. builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

2. Comment ajouter un nouvel �v�nement ?
Actuellement, cette fonctionnalit� n'est pas disponible dans l'interface utilisateur. Vous pouvez utiliser un outil comme Postman pour envoyer une requ�te POST � l'API :
1. POST https://localhost:7151/api/events
Content-Type: application/json

{
    "name": "Nouvel �v�nement",
    "date": "2025-01-01T10:00:00",
    "description": "Description de l'�v�nement",
    "userId": 1
}

3. Comment changer le port du backend ou du frontend ?
�	Backend : Modifiez le fichier launchSettings.json dans le dossier Properties.
�	Frontend : Ajoutez une variable d'environnement PORT avant de lancer le serveur :
1. PORT=4000 npm start

---
Contribuer
Les contributions sont les bienvenues ! Veuillez soumettre une pull request ou ouvrir une issue pour signaler un probl�me.
---#   S m a r t E v e n t A P I  
 #   S m a r t E v e n t A P I  
 "# SmartEventAPI" 
#   S m a r t E v e n t A P I  
 #   S m a r t E v e n t A P I  
 "# SmartEventAPI" 
