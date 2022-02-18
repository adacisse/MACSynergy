using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Projet2Crowdfunding.Service;
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
                    Gender = Gender.Femme,
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
                        Password = AccountService.EncodeMD5("aaaaa"),
                        Role ="participant"
                    }
                },
                new Participant
                {
                    Id = 2,
                    LastName = "Rchouk",
                    FirstName = "Sara",
                    Gender = Gender.Femme,
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
                        Password = AccountService.EncodeMD5("sssss"),
                        Role = "participant"
                    }
                },
                new Participant
                {
                    Id = 3,
                    LastName = "Perez",
                    FirstName = "Juanjo",
                    Gender = Gender.Homme,
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
                        Password = AccountService.EncodeMD5("juanjuan"),
                        Role = "participant"
                    }
                },
                new Participant
                {
                    Id = 4,
                    LastName = "Dupuy",
                    FirstName = "Laura",
                    Gender = Gender.Femme,
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
                        Password = AccountService.EncodeMD5("laulau"),
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
                        Password = AccountService.EncodeMD5("mmmmm"),
                        Role = "admin"
                    }
                },

                new Administrator
                {
                    Id = 2,
                    LastName = "Equisoain",
                    FirstName = "Cristina",
                    PhoneNumber = "4444444444",
                    Type = AdministratorType.volunteer,
                    Account = new Account
                    {
                        Id = 6,
                        Mail = "cristinaequisoain@gmail.com",
                        Password = AccountService.EncodeMD5("ccccc"),
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
                        Password = AccountService.EncodeMD5("floflo"),
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
                        Password = AccountService.EncodeMD5("clacla"),
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
                    " ses activités sont multiples : maraudes, accueil et l’hébergement de personnes en situation d’addiction, activités de réinsertion sociale et professionnelle à destination de personnes en rupture d’emploi ou handicapées," +
                    " hébergement et accompagnement de femmes victimes de violences, soins de personnes en situation de précarité, hébergement et accompagnement de personnes en souffrance psychique",
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

                    Type = ProjectOwnerType.Association,

                    AssociationProof = "/JustificatifsPP/proofAuroreAsso.png",

                    Image = "/ImageAssos/logoAuroreAsso.jpg",

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
                        Password = AccountService.EncodeMD5("aurore"),
                        Role = "po"

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

                    AssociationProof = "/JustificatifsPP/proofwwf.jpeg",

                    Image = "/ImageAssos/logoWwf.jpeg",
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
                        Mail = "ongwwf@gmail.com",
                        Password = AccountService.EncodeMD5("wwf"),
                        Role = "po"
                    }

                },


                new ProjectOwner
                {
                    Id = 3,
                    PhoneNumber = "4499444444",
                    Name = "Play International",
                    Summary = "PLAY International, est née en 1999 d’une conviction profonde : le sport est à la fois un droit fondamental" +
                        " et une façon de résoudre les problématiques de nos sociétés. ",
                    Description = "Ce postulat a inspiré les premières initiatives de terrain de l’ONG dans des contextes d’urgence et de post - urgence.En Bolivie, " +
                        "au Sri Lanka ou en Afghanistan, PLAY a été confronté à la nécessité prégnante d’inventer des dispositifs d’accompagnement permettant" +
                        " à des enfants de surmonter un traumatisme ou apprendre comment se prémunir d’une maladie chronique.Lors de sa première décennie d’existence," +
                        "en intervenant auprès de plusieurs centaines de milliers de bénéficiaires,PLAY et ses partenaires ont démontré que :" +
                        "- Le sport est un langage universel permettant de mobiliser comme peu d’activités sont capable de le faire." +
                        "- Le sport et le jeu ont pleinement leurs places dans le secteur humanitaire et peuvent apporter des réponses concrètes à des problématiques sociales et sanitaires," +
                        "y compris dans les situations les plus précaires." +
                        " L’activité physique et sportive est une matière permettant de faire beaucoup avec peu,notamment lorsque l’on se focalise sur le volet pédagogique. ",
                    HyperLink = "https://www.play-international.org/",

                    VolunteerDescritpion = "DEVENIR BÉNÉVOLE PLAY International suscite votre intérêt ? Vous avez des compétences dans un domaine précis," +
                        "et vous souhaitez vous engager en faveur d’une association défendant des valeurs éducatives ? Intégrez notre communauté de bénévoles et rejoignez l’équipe! Nous recherchons essentiellement des bénévoles pour la course Vertigo et dans des domaines spécifiques tels que la photographie," +
                        "de la traduction et le graphisme. CONTACTEZ - NOUS" +
                        "REJOINDRE LE GROUPE FACEBOOK DES BÉNÉVOLES",

                    Partnership = "PROPARCO, ID4D, Fond francais pour l'environnement mondial ",

                    Type = ProjectOwnerType.ONG,
                    AssociationProof = "/JustificatifsPP/proofPlay.png",
                    Image = "/ImageAssos/logoPlay.png",
                    Status = AssoStatus.published,

                    Newsletter = true,
                    ConfidentialityCharter = true,

                    Address = new Address
                    {
                        Id = 7,
                        StreetName = "rue de Vaugirard",
                        StreetNumber = "173",
                        ZipCode = "75015",
                        City = "Paris",
                        Country = "France"
                    },


                    Account = new Account
                    {
                        Id = 11,
                        Mail = "playinternational@gmail.com",
                        Password = AccountService.EncodeMD5("play"),
                        Role = "po"
                    }

                },

                new ProjectOwner
                {
                    Id = 4,
                    PhoneNumber = "0478697979",
                    Name = "Handicap international",
                    Summary = "Handicap International vient en aide aux populations vulnérables, notamment les personnes handicapées, partout dans le monde où cela est nécessaire. L’association répond à leurs besoins essentiels et spécifiques," +
                    " améliore leurs conditions de vie et les aide à s’insérer dans la société. ",
                    Description = "Depuis plus de 35 ans, nos équipes et nos partenaires démontrent que des solutions sont possibles, en s’appuyant sur les individus, leurs familles et leurs communautés, et en prenant en compte les ressources humaines, les savoir-faire et les matériaux disponibles sur place." +
                    "L’association propose une approche globale qui vise à améliorer les conditions de vie des personnes handicapées ou vulnérables en combinant un ensemble d’actions complémentaires : soins aux blessés," +
                    "appareillage et réadaptation ; actions contre les restes explosifs de guerre; insertion scolaire ou économique; prévention des maladies invalidantes; plaidoyer pour changer les lois nationales ou les normes internationales… Notre mandat L’association intervient dans les situations de pauvreté et d’exclusion, de conflits et de catastrophes aux côtés des personnes handicapées et des populations vulnérables afin:" +
                    "d’améliorer leurs conditions de vie et de promouvoir le respect de leur dignité et de leurs droits fondamentaux " +
                    "d’agir et de témoigner, pour que leurs besoins essentiels soient correctement couverts." +
                    "Nos valeurs, notre charte Guidés par la volonté de promouvoir et défendre la dignité humaine, nous nous reconnaissons dans des principes éthiques auxquels notre approche du handicap donne un sens particulier." +
                    "HUMANITÉ La valeur d’humanité est le socle de notre action de solidarité.Nous considérons chaque personne sans discrimination, et reconnaissons à chacun sa dignité.Notre action est empreinte de respect, de bienveillance et d’humilité." +
                    "INCLUSION Nous promouvons l’inclusion de chacun dans la société et la participation de tous, dans le respect de la diversité, de l’équité et des choix de chacun. Nous reconnaissons la différence comme une richesse." +
                    "En savoir plus sur l'inclusion " +
                    "ENGAGEMENT Nous nous engageons avec détermination et audace, à développer des réponses adaptées, pragmatiques et innovantes. Nous agissons et mobilisons autour de nous pour combattre les injustices." +
                    "INTÉGRITÉ " +
                    "Nous agissons de manière indépendante, professionnelle, désintéressée et transparente." +
                    "Nos bénéficiaires 3969 593 bénéficiaires directs en 2022 (Personnes ayant reçu un bien ou un service au cours d’un projet mis en œuvre par HI ou ses partenaires opérationnels)" +
                    "12 975 481 bénéficiaires indirects en 2020 (Personnes bénéficiant des effets d'un bien ou d’un service reçu par un bénéficiaire direct de HI)" +
                    "Populations exposées aux risques de maladies, de violences ou d’accidents invalidants Personnes ayant subi des traumatismes psychologiques forts Populations vulnérables, en particulier les personnes handicapées" +
                    "Populations réfugiées et populations sinistrées ou déplacées par les crises, les conflits et les catastrophes naturelles" +
                    "Populations exposées au danger des armes, munitions et engins explosifs dans les conflits armés ou dans leurs suitesNos domaines d’intervention" +
                    "Aide d’urgence aux populations victimes de crises et de catastrophes naturelles" +
                    "Prévention des handicaps et des maladies invalidantes" +
                    "Appareillage et rééducation des personnes handicapées" +
                    "Insertion scolaire, sociale et économique Action contre les mines, les restes explosifs de guerre et l'utilisation des armes en zones peuplées" +
                    "Promotion des droits des personnes handicapées",
                    HyperLink = "https://handicap-international.fr/fr/l-association",

                    VolunteerDescritpion = "Vous souhaitez rejoindre Handicap International ? " +
                    "Notre équipe Mobilisation est là pour répondre à vos questions, rendre votre volontariat plus simple et vivre une expérience unique !" +
                    " N'hésitez pas à la contacter par mail : agissez@france.hi.org",

                    Partnership = "alabama, Alcure, Michelin, Airfrance",

                    Type = ProjectOwnerType.Association,
                    AssociationProof = "/JustificatifsPP/proofhandicap.png",
                    Image = "/ImageAssos/handicaplogo.png",
                    Status = AssoStatus.published,

                    Newsletter = true,
                    ConfidentialityCharter = true,

                    Address = new Address
                    {
                        Id = 8,
                        StreetName = "avenue des freres lumieres",
                        StreetNumber = "138",
                        ZipCode = "69008",
                        City = "Lyon",
                        Country = "France"
                    },


                    Account = new Account
                    {
                        Id = 12,
                        Mail = "handicapinternational@gmail.com",
                        Password = AccountService.EncodeMD5("handicap"),
                        Role = "po"
                    }

                },

                 new ProjectOwner
                 {
                     Id = 5,
                     PhoneNumber = "0198521454",
                     Name = "Association Synergie",
                     Summary = "Association Synergie vient en aide aux populations vulnérables, notamment les personnes handicapées, partout dans le monde où cela est nécessaire. L’association répond à leurs besoins essentiels et spécifiques," +
                    " améliore leurs conditions de vie et les aide à s’insérer dans la société. ",
                     Description = "Depuis plus de 35 ans, nos équipes et nos partenaires démontrent que des solutions sont possibles, en s’appuyant sur les individus, leurs familles et leurs communautés, et en prenant en compte les ressources humaines, les savoir-faire et les matériaux disponibles sur place." +
                    "L’association propose une approche globale qui vise à améliorer les conditions de vie des personnes handicapées ou vulnérables en combinant un ensemble d’actions complémentaires : soins aux blessés," +
                    "appareillage et réadaptation ; actions contre les restes explosifs de guerre; insertion scolaire ou économique; prévention des maladies invalidantes; plaidoyer pour changer les lois nationales ou les normes internationales… Notre mandat L’association intervient dans les situations de pauvreté et d’exclusion, de conflits et de catastrophes aux côtés des personnes handicapées et des populations vulnérables afin:" +
                    "d’améliorer leurs conditions de vie et de promouvoir le respect de leur dignité et de leurs droits fondamentaux " +
                    "d’agir et de témoigner, pour que leurs besoins essentiels soient correctement couverts." +
                    "Nos valeurs, notre charte Guidés par la volonté de promouvoir et défendre la dignité humaine, nous nous reconnaissons dans des principes éthiques auxquels notre approche du handicap donne un sens particulier." +
                    "HUMANITÉ La valeur d’humanité est le socle de notre action de solidarité.Nous considérons chaque personne sans discrimination, et reconnaissons à chacun sa dignité.Notre action est empreinte de respect, de bienveillance et d’humilité." +
                    "INCLUSION Nous promouvons l’inclusion de chacun dans la société et la participation de tous, dans le respect de la diversité, de l’équité et des choix de chacun. Nous reconnaissons la différence comme une richesse." +
                    "En savoir plus sur l'inclusion " +
                    "ENGAGEMENT Nous nous engageons avec détermination et audace, à développer des réponses adaptées, pragmatiques et innovantes. Nous agissons et mobilisons autour de nous pour combattre les injustices." +
                    "INTÉGRITÉ " +
                    "Nous agissons de manière indépendante, professionnelle, désintéressée et transparente." +
                    "Nos bénéficiaires 3969 593 bénéficiaires directs en 2022 (Personnes ayant reçu un bien ou un service au cours d’un projet mis en œuvre par HI ou ses partenaires opérationnels)" +
                    "12 975 481 bénéficiaires indirects en 2020 (Personnes bénéficiant des effets d'un bien ou d’un service reçu par un bénéficiaire direct de HI)" +
                    "Populations exposées aux risques de maladies, de violences ou d’accidents invalidants Personnes ayant subi des traumatismes psychologiques forts Populations vulnérables, en particulier les personnes handicapées" +
                    "Populations réfugiées et populations sinistrées ou déplacées par les crises, les conflits et les catastrophes naturelles" +
                    "Populations exposées au danger des armes, munitions et engins explosifs dans les conflits armés ou dans leurs suitesNos domaines d’intervention" +
                    "Aide d’urgence aux populations victimes de crises et de catastrophes naturelles" +
                    "Prévention des handicaps et des maladies invalidantes" +
                    "Appareillage et rééducation des personnes handicapées" +
                    "Insertion scolaire, sociale et économique Action contre les mines, les restes explosifs de guerre et l'utilisation des armes en zones peuplées" +
                    "Promotion des droits des personnes handicapées",
                     HyperLink = "https://associationsynergie.fr/fr/l-association",

                     VolunteerDescritpion = "Vous souhaitez rejoindre Association Synergie ? " +
                    "Notre équipe Mobilisation est là pour répondre à vos questions, rendre votre volontariat plus simple et vivre une expérience unique !" +
                    " N'hésitez pas à la contacter par mail : agissez@france.hi.org",

                     Partnership = "BNparibas, NewYorker, Michelin, Airfrance",

                     Type = ProjectOwnerType.Association,
                     AssociationProof = "/JustificatifsPP/proofSynergieInter.png",
                     Image = "/ImageAssos/logoSynergieInter.png",
                     Status = AssoStatus.registered,

                     Newsletter = true,
                     ConfidentialityCharter = true,

                     Address = new Address
                     {
                         Id = 9,
                         StreetName = "avenue des freres lumieres",
                         StreetNumber = "138",
                         ZipCode = "8547",
                         City = "Wisconscin",
                         Country = "USA"
                     },


                     Account = new Account
                     {
                         Id = 13,
                         Mail = "associationsynergie@gmail.com",
                         Password = AccountService.EncodeMD5("synergie"),
                         Role = "po"
                     }

                 }
            ) ;

                        


            ////Instances Project
            this.Projects.AddRange(
                new Project
                {
                    Id = 1,
                    Status = Status.published,
                    Name = "Addictions-Maladies chroniques",
                    Summary = "L’accompagnement des personnes dans leurs pratiques addictives" +
                    "L’association Aurore est depuis de nombreuses années mobilisée dans l’accompagnement des personnes se trouvant en situation d’addictions : les professionnels mettent en place des actions de prévention," +
                    "de réduction des risques et de soins. Les équipes pluridisciplinaires apportent des réponses adaptées prenant en compte le contexte social.", 
                    //+ "culturel et économique de la personne en lui proposant une offre globale d’accompagnement et de soins pouvant prendre différente formes : sensibiliser et prévenir les personnes sur les comportements à risques, réduire les risques liés à la consommation de drogue, " +
                    //"aider à sortir de l’addiction par le soin communautaire ou l’entraide. ",

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

                    Picture = "/ImagesProject/imgProjetAurore.jpg",
                    Category = Category.health,
                    StartDate  = new DateTime(2021, 11, 9, 16, 5, 7, 123),
                    EndDate = new DateTime(2022, 5, 9, 16, 5, 7, 123),
                    Video = "/VideosProject/VideoAurore.jpg",
                    MaterialDonation = "Médicaments, Matériaux informatiques",
                    Location="Iceland",
                    ProjectOwnerId=1,
                    HeartCounter=5


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

                    Picture = "/ImagesProject/imgWwf.jpeg",
                    Category = Category.environment,
                    StartDate = new DateTime(2022, 1, 29, 15, 6, 8, 245),
                    EndDate = new DateTime(2022, 7, 29, 15, 6, 8, 245),
                    Video = "/VideosProject/Videowwf.jpg",
                    MaterialDonation = "Nourriture",
                    Location = "Lille",
                    ProjectOwnerId = 2,
                    HeartCounter = 5
                },


                new Project
                {
                    Id = 3,
                    Status = Status.published,
                    Name = "Préserver les mangroves du Manambolo",
                    Summary = "Situées sur le littoral Ouest de l’île de Madagascar, les mangroves de la région du Manambolo sont d’une importance cruciale pour les populations locales." +
                    "Elles n’en sont pas moins menacées : leur surexploitation et le changement climatique les détériorent de manière considérable.",

                    Descritpion = "Un écosystème indispensable Les mangroves jouent un rôle essentiel dans la résilience des écosystèmes face au changement climatique et dans la stabilisation des zones côtières." +
                    "Daniel Vallauri, Chargé du programme Forêts au WWF France 60 000 hectares continus le long du littoral malgache," +
                    "les mangroves sont indispensables aux populations locales.Elles leur procurent nourriture, bois de chauffage ainsi que matériaux de construction pour leurs habitations.Elles sont aussi dotées de vertus médicinales." +
                    "Face au changement climatique et aux phénomènes naturels extrêmes, la mangrove joue également un rôle capital puisqu’elle protège l’intérieur de la côte des dégâts cycloniques et de l’érosion.Enfin,elle filtre l’eau et stocke le carbone," +
                    "comme le font les forêts terrestres. A Madagascar,es mangroves de la région du Manambolo protègent notamment la future Aire Marine Protégée de l’archipel des Îles Barren contre la sédimentation venant du versant ouest de l’île.Elles garantissent également la protection de la zone humide de Manambolomaty(classée site RAMSAR)," +
                    "de la forêt primaire de Tsimembo ainsi que des plaines rizicoles de Bemamba et de Soahany contre les effets néfastes de l’augmentation du niveau de la mer causée par le changement climatique." +
                    "C’est grâce à ces écosystèmes uniques que poissons et invertébrés migrent vers les récifs et la haute mer afin de s’y réfugier" +
                    " pour se nourrir et se reproduire.La pêche représente dans la région la principale source de revenus," +
                    " mais utilise encore des techniques non durables et les techniques de stockage et de conditionnement sont peu efficaces." +
                    " Sur 15 kg de crabes pêchés par pêcheur et par jour en moyenne, 15% sont perdus du fait des mauvaises conditions de stockage. " +
                    "Ce chiffre grimpe jusqu’à 50% lors de la saison des pluies. Le retard de développement chez les pêcheurs du Manambolo s’explique, entre autres," +
                    "par leur isolement et la difficulté qu’ils ont à accéder au marché régional.Par conséquent," +
                    "leur poids dans les négociations avec les collecteurs est faible bien qu’ils soient organisés en groupement informel.Les communautés de base(COBA), acteurs clés pour la gestion des ressources naturelles," +
                    "manquent souvent de ressources techniques et organisationnelles pour être pleinement efficaces et aucune politique n’intègre véritablement les enjeux de gestion durable des mangroves.",

                    Picture = "/ImagesProject/mangroveimage2.jpeg",
                    Category = Category.environment,
                    StartDate = new DateTime(2021, 12, 9, 15, 6, 8, 200),
                    EndDate = new DateTime(2022, 8, 9, 15, 6, 8, 200),
                    Video = "/VideosProject/mangrovevideo.jpeg",
                    MaterialDonation = "Barques motorisées",
                    Location = "Troyes",
                    ProjectOwnerId = 2,
                    HeartCounter = 5
                },

                new Project
                {
                    Id = 4,
                    Status = Status.published,
                    Name = "EJO - PROJET D’APPUI POUR UNE ÉDUCATION ACTIVE ET INCLUSIVE DE TOUS LES ENFANTS.",

                    Summary = "Ce programme sera déployé jusqu'en 2022 au Burundi, au Kosovo, au Sénégal," +
                    " au Libéria et, dans le cadre de son incubateur, dans d'autres pays d'Afrique de l'Ouest.",
                    //+" Il contribuera à rendre accessible une éducation de qualité (Objectif du Développement Durable n°4) " 
                    //+ "pour les publics les plus vulnérables comme les filles, les enfants en situation de handicap ou les minorités" +
                    //" communautaires.",

                    Descritpion = "Face aux enjeux de qualité de l’éducation et de son accès par les populations " +
                    "les plus vulnérables, PLAY propose un projet reposant sur la création et la diffusion d’un " +
                    "programme pédagogique fondé entre autre sur la Playdagogie, méthode de pédagogie active et " +
                    "participative développée par l’ONG. Ces contenus seront diffusés à travers des programmes de" +
                    " formations d’enseignants et d’animateurs sportifs recevant les kits thématiques. " +
                    "Projet déployé dans les secteurs de l’éducation formelle et informelle, il s’attachera" +
                    " à créer des passerelles entre les deux pour renforcer la continuité de la prise en charge" +
                    " éducative des enfants. Il s’agira, lorsque possible, de travailler sur l’intégration des " +
                    "méthodes socio-sportives dans les cursus de formation des enseignants et animateurs sportifs" +
                    " en collaboration étroite avec les pouvoirs publics." +
                    "RÉSULTATS ATTENDUSPlus de 80 000 enfants, dont 40 % de filles qui acquièrent une meilleure compréhension des enjeux de scolarisation," +
                    "et compétences de vie liées à l’inclusion de leurs pairs en situation de vulnérabilité." +
                    "Plus de 1000 professionnels éducatifs formés qui acquièrent des compétences permettant de déployer des séances de jeux socio - sportifs et de Playdagogie reconnues officiellement par les Ministères des Sports," +
                    "et de l’Education nationale." +
                    "Plus de quinze institutions et associations locales s’inscrivent dans une dynamique d’intégration du sport  comme outil d’éducation au sein de leurs dispositifs.",

                    Picture = "/ImagesProject/Playimage.jpeg",
                    Category = Category.education,
                    StartDate = new DateTime(2021, 9, 19, 15, 6, 8, 245),
                    EndDate = new DateTime(2022, 3, 19, 15, 6, 8, 245),
                    Video = "/VideosProject/PlayVideo.html",
                    MaterialDonation = "Materiaux sportifs",
                    Location = "New York",
                    ProjectOwnerId = 3,
                    HeartCounter = 5
                },

                new Project
                {
                    Id = 5,
                    Status = Status.published,
                    Name = "Pour inventer aujourd'hui, les réponses humanitaires de demain...",

                    Summary = "Handicap International vient en aide aux populations vulnérables, notamment les personnes handicapées, partout dans le monde où cela est nécessaire. L’association répond à leurs besoins essentiels et spécifiques, " +
                    "améliore leurs conditions de vie et les aide à s’insérer dans la société.",

                    Descritpion = "Depuis plus de 35 ans, nos équipes et nos partenaires démontrent que des solutions sont possibles, en s’appuyant sur les individus, leurs familles et leurs communautés, et en prenant en compte les ressources humaines, les savoir-faire et les matériaux disponibles sur place." +
                    "L’association propose une approche globale qui vise à améliorer les conditions de vie des personnes handicapées ou vulnérables en combinant un ensemble d’actions complémentaires : soins aux blessés," +
                    "appareillage et réadaptation ; actions contre les restes explosifs de guerre; insertion scolaire ou économique; prévention des maladies invalidantes; plaidoyer pour changer les lois nationales ou les normes internationales… Notre mandat L’association intervient dans les situations de pauvreté et d’exclusion, de conflits et de catastrophes aux côtés des personnes handicapées et des populations vulnérables afin:" +
                    "d’améliorer leurs conditions de vie et de promouvoir le respect de leur dignité et de leurs droits fondamentaux " +
                    "d’agir et de témoigner, pour que leurs besoins essentiels soient correctement couverts." +
                    "Nos valeurs, notre charte Guidés par la volonté de promouvoir et défendre la dignité humaine, nous nous reconnaissons dans des principes éthiques auxquels notre approche du handicap donne un sens particulier." +
                    "HUMANITÉ La valeur d’humanité est le socle de notre action de solidarité.Nous considérons chaque personne sans discrimination, et reconnaissons à chacun sa dignité.Notre action est empreinte de respect, de bienveillance et d’humilité." +
                    "INCLUSION Nous promouvons l’inclusion de chacun dans la société et la participation de tous, dans le respect de la diversité, de l’équité et des choix de chacun. Nous reconnaissons la différence comme une richesse." +
                    "En savoir plus sur l'inclusion " +
                    "ENGAGEMENT Nous nous engageons avec détermination et audace, à développer des réponses adaptées, pragmatiques et innovantes. Nous agissons et mobilisons autour de nous pour combattre les injustices." +
                    "INTÉGRITÉ " +
                    "Nous agissons de manière indépendante, professionnelle, désintéressée et transparente." +
                    "Nos bénéficiaires 3969 593 bénéficiaires directs en 2022 (Personnes ayant reçu un bien ou un service au cours d’un projet mis en œuvre par HI ou ses partenaires opérationnels)" +
                    "12 975 481 bénéficiaires indirects en 2020 (Personnes bénéficiant des effets d'un bien ou d’un service reçu par un bénéficiaire direct de HI)" +
                    "Populations exposées aux risques de maladies, de violences ou d’accidents invalidants Personnes ayant subi des traumatismes psychologiques forts Populations vulnérables, en particulier les personnes handicapées" +
                    "Populations réfugiées et populations sinistrées ou déplacées par les crises, les conflits et les catastrophes naturelles" +
                    "Populations exposées au danger des armes, munitions et engins explosifs dans les conflits armés ou dans leurs suitesNos domaines d’intervention" +
                    "Aide d’urgence aux populations victimes de crises et de catastrophes naturelles" +
                    "Prévention des handicaps et des maladies invalidantes" +
                    "Appareillage et rééducation des personnes handicapées" +
                    "Insertion scolaire, sociale et économique Action contre les mines, les restes explosifs de guerre et l'utilisation des armes en zones peuplées" +
                    "Promotion des droits des personnes handicapées",

                    Picture = "/ImagesProject/handicapimage.jpeg",
                    Category = Category.humanitarian,
                    StartDate = new DateTime(2021, 5, 10, 15, 6, 8, 245),
                    EndDate = new DateTime(2022, 3, 19, 15, 6, 8, 245),
                    Video = "/VideosProject/videoHandicap.html",
                    MaterialDonation = "Fauteuils roulants, Prothéses, Kits scolaires",
                    Location = "Nwagadougou",
                    ProjectOwnerId = 4,
                    HeartCounter = 5
                }
            );
            this.Favorites.AddRange(
                new Favorite
                {
                    Id = 1,
                    
                    ProjectId=1,
                    ParticipantId=1
                },
                new Favorite
                {
                    Id = 2,
                    
                    ProjectId = 2,
                    ParticipantId = 1
                },
                new Favorite
                {
                    Id = 3,
                    
                    ProjectId = 3,
                    ParticipantId = 3
                },
                new Favorite
                {
                    Id = 4,
                    
                    ProjectId = 3,
                    ParticipantId = 4
                },
                new Favorite
                {
                    Id = 5,
                   
                    ProjectId = 5,
                    ParticipantId = 4
                }
                ) ;

            ////Instances PPs
            this.Collections.AddRange(
                new Collection
                {
                    Amount = 100,
                    ProjectId = 1
                },
                new Collection
                {
                    Amount = 20,
                    ProjectId = 2
                },
                new Collection
                {
                    Amount = 250,
                    ProjectId = 3
                },
                new Collection
                {
                    Amount = 3000,
                    ProjectId = 4
                },
                new Collection
                {
                    Amount = 1480,
                    ProjectId = 5
                }
            );


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
               .HasIndex(u => u.ProjectId)
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


