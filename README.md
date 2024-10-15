1 ***** builder  project  HahnWebAPI


Bonjour, pour builder le projet Web API, voici les étapes suivantes :

- Étape 1 :
Changer la chaîne de connexion dans le fichier appsettings.json :
Server=nom_du_serveur;Database=HahnDb;Trusted_Connection=True;TrustServerCertificate=True;

 - Étape 2 :
Restaurer la sauvegarde de la base de données présente dans le projet "Hahn.Shared".
Dans le dossier "ScriptsDatabase", exécuter le script à l'aide de SQL Server pour créer la base de données avec de donnée temporaire

 - Étape 3 :
Exécuter le projet "HahnWebApi".


2 ***** builder  project  angular Project 

- Étape 1 :
- 
     - Rechercher toutes les occurrences du mot 'TaskApiUrl' dans le code et les remplacer par l'URL de l'API web,
        à savoir : https://localhost:7054/api/Ticket/."
