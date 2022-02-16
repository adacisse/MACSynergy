using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<PayPalAccount> PayPalAccounts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectOwner> ProjectOwners { get; set; }
        public DbSet<Report> Reports { get; set; }
        //public DbSet<StatisticsPlateform> StatisticsPlateforms { get; set; }
        //public DbSet<StatisticsProjet> StatisticsProjets { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrrrrr;database=Project2Crowdfunding");
        }

        public void InitializedDB()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            //Instances Participant
            this.Participants.AddRange(
                new Participant
                {
                    Id = 1,
                    LastName = "Cisse",
                    FirstName = "Ada",
                    Gender = Gender.Female,
                    PhoneNumber = "6666666666",
                    Birthdate = DateTime.Parse("2013-07-04"),
                    Newsletter = false,
                    ConfidentialityCharter = true,
                    Address = new Address
                    {
                        Id = 1,
                        StreetName = "Rue de la fleur",
                        StreetNumber = "12",
                        ZipCode = "57888",
                        City = "Toulouse",
                        Country = "France"
                    },
                    Account = new Account
                    {
                        Id = 1,
                        Mail = "adacisse@gmail.com",
                        Password = "aaaaa",
                        Role ="participant"
                    }
                },
                new Participant
                {
                    Id = 2,
                    LastName = "Rchouk",
                    FirstName = "Sara",
                    Gender = Gender.Female,
                    PhoneNumber = "5555555555",
                    Birthdate = DateTime.Parse("2011-03-14"),

                    Newsletter = true,
                    ConfidentialityCharter = true,
                    Address = new Address
                    {
                        Id = 2,
                        StreetName = "Rue du presidant",
                        StreetNumber = "24",
                        ZipCode = "75007",
                        City = "Paris",
                        Country = "France"
                    },
                    Account = new Account
                    {
                        Id = 2,
                        Mail = "sara.rchouk@gmail.com",
                        Password = "sssss",
                        Role = "participant"
                    }
                },
                new Participant
                {
                    Id = 3,
                    LastName = "Perez",
                    FirstName = "Juanjo",
                    Gender = Gender.Male,
                    PhoneNumber = "4444114444",
                    Birthdate = DateTime.Parse("1987-09-12"),

                    Newsletter = true,
                    ConfidentialityCharter = true,
                    Address = new Address
                    {
                        Id = 3,
                        StreetName = "Calle de las rosas",
                        StreetNumber = "22",
                        ZipCode = "36611",
                        City = "Málaga",
                        Country = "Espagne"
                    },
                    Account = new Account
                    {
                        Id = 3,
                        Mail = "juanjoperez@gmail.com",
                        Password = "juanjuan",
                        Role = "participant"
                    }
                },
                new Participant
                {
                    Id = 4,
                    LastName = "Dupuy",
                    FirstName = "Laura",
                    Gender = Gender.Female,
                    PhoneNumber = "3333113333",
                    Birthdate = DateTime.Parse("1994-02-09"),
                    Newsletter = false,
                    ConfidentialityCharter = true,
                    Address = new Address
                    {
                        Id = 4,
                        StreetName = "Calle de abril",
                        StreetNumber = "7",
                        ZipCode = "84337",
                        City = "Sevilla",
                        Country = "Espagne"
                    },
                    Account = new Account
                    {
                        Id = 4,
                        Mail = "lauradupuy@gmail.com",
                        Password = "laulau",
                        Role = "participant"
                    }
                }

            );


            //Instances Gestionnaires
            this.Administrators.AddRange(
                new Administrator
                {
                    Id = 1,
                    LastName = "Faucillon",
                    FirstName = "Matthieu",
                    PhoneNumber = "3333333333",
                    Type = AdministratorType.employee,
                    Account = new Account
                    {
                        Id = 5,
                        Mail = "matthieu.faucillon@gmail.com",
                        Password = "mmmmm",
                        Role = "admin"
                    }
                },

                new Administrator
                {
                    Id = 2,
                    LastName = "Equisoain",
                    FirstName = "Cristina",
                    PhoneNumber = "4444444444",
                    Account = new Account
                    {
                        Id = 6,
                        Mail = "cristinaequisoain@gmail.com",
                        Password = "ccccc",
                        Role = "admin"
                    }
                },

                new Administrator
                {
                    Id = 3,
                    LastName = "Lacroix",
                    FirstName = "Florent",
                    PhoneNumber = "3333333311",
                    Type = AdministratorType.employee,
                    Account = new Account
                    {
                        Id = 7,
                        Mail = "florentlacroix@gmail.com",
                        Password = "floflo",
                        Role = "admin"
                    }
                },

                new Administrator
                {
                    Id = 4,
                    LastName = "Martin",
                    FirstName = "Clara",
                    PhoneNumber = "1133333333",
                    Type = AdministratorType.volunteer,
                    Account = new Account
                    {
                        Id = 8,
                        Mail = "clara.martin@gmail.com",
                        Password = "clacla",
                        Role = "admin"
                    }
                }
            );

            ////Instances PPs
            this.ProjectOwners.AddRange(
                new ProjectOwner
                {
                    Id = 1,
                    PhoneNumber = "0173000230",
                    Name = "Aurore Association",
                    Summary = "Accueillir et accompagner vers l’autonomie les personnes en situation de précarité ou d’exclusion via l’hébergement, les soins et l’insertion.",
                    Description = "Créée en 1871, l’association Aurore héberge,soigne et accompagne plus de 41 300 personnes en situation de précarité" +
                    " ou d’exclusion vers une insertion sociale et professionnelle." +
                    "Reconnue d’utilité publique depuis 1875, Aurore s’appuie sur son expérience pour proposer et expérimenter des formes innovantes" +
                    " de prises en charge, qui s’adaptent à l’évolution des phénomènes de précarité et d’exclusion." +
                    " L’association travaille en partenariat avec l’Etat, les collectivités locales, les régions, les départements et les communes." +
                    "Le dialogue avec les autorités qui financent les actions est permanent, en cohérence avec les besoins recensés sur " +
                    "ses territoires d'intervention. Aurore intervient principalement en Île-de-France et dans 7 autres régions (Nouvelle-Aquitaine, " +
                    "Occitanie, Centre-Val de Loire, Auvergne-Rhône-Alpes, Grand-Es,Hauts-de-France et Pays-de-la-Loire). " +
                    "Organisées autour de trois missions, hébergement" +
                    "soin et insertion," +
                    " ses activités sont multiples : maraudes, accueil et l’hébergement de personnes en situation d’addiction, activités de réinsertion sociale et professionnelle à destination de personnes en rupture d’emploi ou handicapées, hébergement et accompagnement de femmes victimes de violences, soins de personnes en situation de précarité, hébergement et accompagnement de personnes en souffrance psychique",
                    HyperLink = "https://aurore.asso.fr/association",

                    VolunteerDescritpion = "Les bénévoles nous apportent du bien - être et du savoir," +
                    "ils nous soutiennent pour avancer dans notre vie.C'est l'art de la gratuité du cœur Vous avez une envie de partager," +
                    "un désir de vous engager, une compétence à faire vivre...Sans hésiter, faites nous une proposition d’activité!" +
                    "Vous avez envie d’animer un atelier photo ? du coaching ? du yoga ? " +
                    "Des exemples de ce que font les bénévoles à nos côtés : animation d’ateliers divers," +
                    "cours de français,sorties culturelles, aide au fonctionnement de l’épicerie solidaire, " +
                    "initiation à l’informatique, vestiaire, bien - être, sport, jardinage, accueil, traductions, conseil…" +
                    "Comme plus de 850 personnes, rejoignez - nous sur des missions bénévoles et devenez un acteur solidaire. S’engager bénévolement à AURORE, " +
                    "c’est se donner les moyens de l’action, auprès d’une grande association laïque.C’est agir en solidarité et avec des principes humanistes.",
                    Partnership = "Dons solidaire, Le chainon manquant, L'agence du don en nature",

                    Type = ProjectOwnerType.association,

                    AssociationProof = "/src/wwwroot/css/LogoAssociation/proofAuroreAsso",

                    Image = "/src/wwwroot/css/LogoAssociation/logoAuroreAsso",

                    Status = AssoStatus.published,
                    Newsletter = true,
                    ConfidentialityCharter = true,
                    Address = new Address
                    {
                        Id = 5,
                        StreetNumber = "34",
                        StreetName = "Boulevard sebastopol",
                        ZipCode = "75004",
                        City = "Paris",
                        Country = "France"
                    },
                    Account = new Account
                    {
                        Id = 9,
                        Mail = "associationaurore@gmail.com",
                        Password = "aurore"

                    }


                },

                       new ProjectOwner
                       {
                           Id = 2,
                           PhoneNumber = "0638023453",
                           Name = "WWF",
                           Summary = "Depuis 1973, le WWF France agit au quotidien afin d'offrir aux générations futures une planète vivante. Nous œuvrons pour mettre un frein à la dégradation de l'environnement et construire un avenir où les humains vivent en harmonie avec la nature." +
                           " Constituée de bénévoles, Rêv’Animal a pour but :de prendre en charge,de soigner, de stériliser, et de replacer des animaux",

                           Description = "Le Fonds Mondial pour la Nature (WWF) est l'une des toutes premières organisations indépendantes de protection de l'environnement dans le monde" +
                           ", avec un réseau actif dans plus de 100 pays et fort du soutien de près de 6 millions de membres." +
                           " Le WWF France, Fondation reconnue d'utilité publique, oeuvre pour une planète vivante depuis Paris, Marseille, les Alpes," +
                           " la Guyane et la Nouvelle-Calédonie.Le siège du WWF International − le secrétariat de l’organisation au niveau mondial − est situé à Gland en Suisse. " +
                           "Il dirige et coordonne le réseau des bureaux du WWF dans le monde entier, favorise les partenariats mondiaux et coordonne les campagnes internationales. " +
                           "La Fondation était jusqu'à la fin de l'année 2017, présidée par Yolanda Kakabadse et dirigée par Marco Lambertini. En 2018, Pavan Sukhdev, " +
                           "ancien directeur de UN Environnement a succédé à Yolanda Kakabadse. Son Altesse Royale le duc d'Édimbourg en est le Président émérite.",


                           HyperLink = "https://www.wwf.fr/",
                           VolunteerDescritpion = "Rejoignez ceux, membres et donateurs, partenaires et sympathisants, qui ont bâti avec nous une association riche aujourd’hui de 220 000" +
                           " donateurs et de milliers de bénévoles, toujours disponibles pour se mobiliser et démultiplier notre capacité d’action !",

                           Partnership = "Fiat Panis, UNESCO",

                           Type = ProjectOwnerType.ONG,

                           AssociationProof = "/src/wwwroot/css/LogoEtImageAssociation/proofwwf",

                           Image = "/src/wwwroot/css/LogoEtImageAssociation//logoWwf",
                           Status = AssoStatus.published,
                           Newsletter = false,
                           ConfidentialityCharter = true,
                           Address = new Address
                           {
                               Id = 6,
                               StreetName = "Rue Jean Vallet",
                               StreetNumber = "3",
                               ZipCode = "59630",
                               City = "Bourbourg",
                               Country = "France"
                           },

                           Account = new Account
                           {
                               Id = 10,
                               Mail = "ongbwwf@gmail.com",
                               Password = "bww"
                           }

                       }
                );


            ////Instances Project
            this.Projects.AddRange(
         new Project
         {
             Id = 1,
             Status = Status.published,
             Name = "Addictions-Maladies chroniques",
             Summary = "L’accompagnement des personnes dans leurs pratiques addictives" +
             "L’association Aurore est depuis de nombreuses années mobilisée dans l’accompagnement des personnes se trouvant en situation d’addictions : les professionnels mettent en place des actions de prévention," +
             "de réduction des risques et de soins. Les équipes pluridisciplinaires apportent des réponses adaptées prenant en compte le contexte social," +
             "culturel et économique de la personne en lui proposant une offre globale d’accompagnement et de soins pouvant prendre différente formes : sensibiliser et prévenir les personnes sur les comportements à risques, réduire les risques liés à la consommation de drogue, " +
             "aider à sortir de l’addiction par le soin communautaire ou l’entraide. ",

             Descritpion = "De quoi parle-t-on lorsqu’il est question d’abstinence ? C’est le thème sur lequel ont phosphoré cinquante usagers et professionnels de quatre dispositifs d’Aurore et de deux partenaires historiques de l’association. Un débat s’est déroulé tout au long de la journée du 24 novembre 2021. La place de l’abstinence dans le parcours de soin et de rétablissement, l’intérêt de proposer l’expérience d’une fenêtre d’abstinence, la question des traitements médicamenteux face aux demandes d’abstinence… loin des stéréotypes, les réflexions issues des expériences vécues et des positionnements professionnels ont permis à l’ensemble des participants d’exposer différentes approches des addictions." +
             "Etablir une réflexion commune Dans son discours d’ouverture, Florian Guyot, directeur général de l’association, précise la portée d’un tel travail :" +
             " « C’est une journée importante, parce que se réunir pour élaborer ensemble autour de pratiques, et essayer de co - construire  de capitaliser, est quelque chose auquel je tiens beaucoup ». L’association Aurore, " +
             "comme l’ensemble de la société,est de plus en plus confrontées aux enjeux des addictions.De la consommation de crack dans les espaces publics aux nouvelles pratiques comme le « chemsex »," +
             "les consommations excessives ont un impact lourd sur les consommateurs, notamment sur leur situation sociale et psychologique. " +
             "L’association Aurore, experte sur ces questions depuis plusieurs décennies, propose différentes approches.Les dispositifs s’adaptent aux situation et aux spécificités des publics.Sans chercher à opposer les méthodes," +
             "s’arrêter le temps d’une journée sur la clinique de l’abstinence, était pour le moins nécessaire." +
             "Le SSR La Maison de Kate »,le CSAPA « Revivre, l’amitié sans alcool, les communautés thérapeutiques « Maison André le Gorrec » et « d’Aubervilliers » mais également l’Espoir du Val d’Oise et le Centre de Psychothérapie d’Osny… Six dispositifs présentant six façons très complémentaires de travailler l’abstinence comme outils d’accompagnement thérapeutique." +
             "Concrètement, quel travail autour de l’abstinence ? La « fenêtre d’abstinence » proposée aux patients, implique un travail complet autour de la capacité de changement et de la créativité.L’abstinence est un préalable et non une fin en soi et sert de socle à la mise en place « d’autre chose »." +
             "Le groupe,l’entraide,l’exemplarité des plus anciens,le travail sur les émotions, la prévention de la rechute,la prise de conscience de dépendances autres que celles aux produits," +
             "tout ceci fait émerger chez l’usager des changements de comportements, qui eux - mêmes, permettent de mettre à distance la consommation." +
             "Ainsi, notre vision de la dépendance influence les approches, est - ce une « maladie » de type allergique dont le seul remède est l’abstinence pour échapper à une issue fatale,ou peut - elle être guérie à un moment donné et ainsi permettre aux patients de contrôler leur consommation ? Le concept de maladie implique l’existence de symptômes,que faire du manque," +
             "du vide, de la souffrance, de l’obsession et de la compulsion, de la frustration, de la peur, de l’inconfort, de la dépression, de la souffrance etc… " +
             "« Savoir que c’est une maladie permet de comprendre les compulsions, les comportements et de pouvoir agir dessus," +
             "mais aussi de déculpabiliser ». Tous s’accordent à dire qu’un travail sur le changement des comportements est nécessaire et que cela passe par l’entraide et le groupe, dénominateurs communs des six services présents « L’abstinence," +
             "c’est la construction d’un état d’esprit » indique un usager dans la salle." +
             "communautaire," +
             "le suivi individuel,la rechute et sa prévention et la gestion des traitements.Après une matinée de réflexion à large spectre,il s’agissait de concentrer la focale sur des enjeux de terrains et de pratiques.Les échanges," +
             "très riches là encore, ont permis de montrer l’impact de l’abstinence dans les démarches de soin.Jean - Pierre Couteron, psychologue clinicien et ancien président de la Fédération Addiction et Jean - Maxence Granier, ont pu faire la synthèse des échanges dans un dialogue improvisé.C’est surtout la notion de lien qui ressortira de leur échange.Comme si l’abstinence permettait de structurer les approches," +
             "individuelles comme groupales autour d’un « terrain commun clairement défini," +
             "avec un groupe et une équipe ». Remettre l’usager au centre. Placer les usagers au centre des démarches d’accompagnement est probablement ce qui ressort en premier de cette journée, dont les actes seront bientôt disponibles. « Pour conclure le plus important est de remettre le patient au centre," +
             "de savoir ce que la personne veut, et de ne pas essayer de la faire rentrer dans un modèle » nous dit Alexandra Roy, counsellor au Centre de Psychothérapie d’Osny. Comme de nombreux intervenants l’ont rappelé à plusieurs reprises : le soin est un processus," +
             "dont le travail en équipe et le groupe sont des ciments essentiels. En 2022, la réflexion se poursuivra en collaboration avec la Fédération Addiction autour d’un colloque. " +
             "« Le meilleur tranquillisant est un bon sentiment d’appartenance » " +
             "Boris Cyrulnik",

             Picture = "/src/wwwroot/css/LogoEtImageAssociation/imgProjetAurore",
             Category = Category.health,
                            StartDate = DateTime.Parse("2021-12-12"),
                            EndDate = DateTime.Parse("2022-04-12"),
                            Video = "/src/wwwroot/css/LogoEtImageAssociation/VideoAurore",
             MaterialDonation = "Médicaments, Matériaux informatiques",

         },

         new Project
         {
             Id = 2,
             Status = Status.published,
             Name = "Doubler la population mondiale de tigres",
             Summary = "C’est sans doute la stratégie de restauration la plus ambitieuse jamais entreprise pour une seule espèce." +
             " En 2010, alors que le nombre de tigres est au plus bas, les gouvernements des 13 pays qui abritent encore " +
             "le félin s’engagent à multiplier sa population par deux d’ici 2022. L’initiative Tiger X 2 est lancée.",

             Descritpion = "En tant que grand prédateur, Panthera tigris joue un rôle clé dans le maintien de la bonne santé" +
             " de son écosystème et des services vitaux rendus par ce dernier aux autres espèces et aux populations locales :" +
             " approvisionnement en nourriture et en eau douce, notamment. On parle d’espèce parapluie car sa protection garantit" +
             " celle des autres espèces avec lesquelles il partage son habitat. Par sa seule présence, le félin renforce également" +
             " l’attractivité de la zone dans laquelle il vit. Stimulant l’activité touristique, il procure des sources de revenus " +
             "alternatives aux communautés vivant autour de son aire de répartition. Mais aujourd’hui, le félin est gravement menacé." +
             "En danger d’extinction,l’espèce est inscrite sur la liste rouge de l'UICN. " +
             "Recherché pour sa peau mais aussi pour diverses parties de son corps, supposées soigner plusieurs pathologies dans la médecine " +
             "traditionnelle chinoise, Panthera tigris est victime d’un trafic international, exercé par de puissantes mafias. Si sa chasse est" +
             " désormais interdite, en Asie, on continue de tuer le tigre pour s’approprier symboliquement sa puissance, fabriquer des médicaments" +
             " utilisés dans la médecine traditionnelle ou encore pour en faire des articles de décoration, des tentures, des tapis ou des objets" +
             " souvenirs. De 2000 à 2018, 1142 saisies de tigres ont été réalisées dans 32 pays, correspondant à 2359 tigres, soit au moins 124 " +
             "animaux par an. La destruction de son habitat constitue également une menace sérieuse pour le félin. Il ne subsiste plus aujourd’hui " +
             "que dans 7% de son aire de répartition historique et 43% de ses habitats restants pourraient bientôt être perdus en raison de " +
             "l’expansion agricole et de l’urbanisation. ",

             Picture = "/src/wwwroot/css/LogoEtImageAssociation/imgWwf",
             Category = Category.environment,
             StartDate = DateTime.Parse("2022-01-09") ,
             EndDate = DateTime.Parse("2022-07-09"),
             Video = "/src/wwwroot/css/LogoEtImageAssociation/Videowwf",
             MaterialDonation = "Nourriture"
         }

     );



            //new ProjectOwner
            //{
            //    Id = 2,
            //    PhoneNumber = "4499455444",
            //    Name = ,
            //    Summary = ,
            //    Description = ,
            //    HyperLink = ,
            //    VolunteerDescritpion = ,
            //    Partnership = ,
            //    Type = ProjectOwnerType.association,
            //    AssociationProof = ,
            //    Image = ,
            //    Status = AssoStatus.published,
            //    Address = new Address
            //    {
            //        Id = 6,
            //        StreetName = "Street of Wansington",
            //        StreetNumber = "31A",
            //        ZipCode = "58943",
            //        City = "Liverpool",
            //        Country = "Anglaterre"
            //    },
            //    Account = new ProjectOwnerAccount
            //    {
            //        Id = 2,
            //        Newsletter = false,
            //        ConfidentialityCharter = true,
            //        Account = new Account
            //        {
            //            Id = 10,
            //            Mail = "",
            //            Password = ""
            //        }
            //    }
            //},



            //            new ProjectOwner
            //            {
            //                Id = 3,
            //                PhoneNumber = "4499444444",
            //                Name = ,
            //                Summary = ,
            //                Description = ,
            //                HyperLink = ,
            //                VolunteerDescritpion = ,
            //                Partnership = ,
            //                Type = ProjectOwnerType.association,
            //                AssociationProof = ,
            //                Image = ,
            //                Status = AssoStatus.registered,
            //                Address = new Address
            //                {
            //                    Id = 7,
            //                    StreetName = "Calle de Barcelona",
            //                    StreetNumber = "52",
            //                    ZipCode = "36666",
            //                    City = "Madrid",
            //                    Country = "Espagne"
            //                },
            //                Account = new ProjectOwnerAccount
            //                {
            //                    Id = 3,
            //                    Newsletter = true,
            //                    ConfidentialityCharter = true,
            //                    Account = new Account
            //                    {
            //                        Id = 11,
            //                        Mail = "",
            //                        Password = ""
            //                    }
            //                }
            //            },

            //            new ProjectOwner
            //            {
            //                Id = 4,
            //                PhoneNumber = "4499444444",
            //                Name = ,
            //                Summary = ,
            //                Description = ,
            //                HyperLink = ,
            //                VolunteerDescritpion = ,
            //                Partnership = ,
            //                Type = ProjectOwnerType.ONG,
            //                AssociationProof = ,
            //                Image = ,
            //                Status = AssoStatus.published,
            //                Address = new Address
            //                {
            //                    Id = 8,
            //                    StreetName = "Rue de la gare",
            //                    StreetNumber = "43",
            //                    ZipCode = "97532",
            //                    City = "Bordeaux",
            //                    Country = "France"
            //                },
            //                Account = new ProjectOwnerAccount
            //                {
            //                    Id = 4,
            //                    Newsletter = true,
            //                    ConfidentialityCharter = true,
            //                    Account = new Account
            //                    {
            //                        Id = 12,
            //                        Mail = "",
            //                        Password = ""
            //                    }
            //                }
            //            },

            //            new ProjectOwner
            //            {
            //                Id = 5,
            //                PhoneNumber = "4499444444",
            //                Name = ,
            //                Summary = ,
            //                Description = ,
            //                HyperLink = ,
            //                VolunteerDescritpion = ,
            //                Partnership = ,
            //                Type = ProjectOwnerType.ONG,
            //                AssociationProof = ,
            //                Image = ,
            //                Status = AssoStatus.registered,
            //                Address = new Address
            //                {
            //                    Id = 9,
            //                    StreetName = "",
            //                    StreetNumber = "37",
            //                    ZipCode = "17634",
            //                    City = "Strasbourg",
            //                    Country = "France"
            //                },
            //                Account = new ProjectOwnerAccount
            //                {
            //                    Id = 5,
            //                    Newsletter = false,
            //                    ConfidentialityCharter = true,
            //                    Account = new Account
            //                    {
            //                        Id = 13,
            //                        Mail = "",
            //                        Password = ""
            //                    }
            //                }
             //          }
            //      );

            ////Instances Projects
            //this.Projects.AddRange(

            //);



            this.SaveChanges(); 
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>()
                .HasIndex(u => u.AccountId)
                .IsUnique();

            modelBuilder.Entity<Administrator>()
                .HasIndex(u => u.AccountId)
                .IsUnique();

            modelBuilder.Entity<ProjectOwner>()
                .HasIndex(u => u.AccountId)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .HasIndex(u => new { u.Mail, u.Password })
                .IsUnique();

            modelBuilder.Entity<Collection>()
               .HasIndex(u => u.DonationId)
               .IsUnique();

            modelBuilder.Entity<Favorite>()
              .HasIndex(u => new { u.ProjectId, u.ParticipantId })
              .IsUnique();

            modelBuilder.Entity<ProjectOwner>()
               .HasIndex(u => u.Name)
               .IsUnique();

        }

    }
}


