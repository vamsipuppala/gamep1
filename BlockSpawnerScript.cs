using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class BlockSpawnerScript : MonoBehaviour
{

    public GameObject blockPrefab;
    public Vector3 position;
    public string text1="M";
    public TextMesh textComponent;
    //public float pauseDuration = 1f;
    //public Vector3 moveDirection = Vector3.down;

    public float fallSpeed = 1.0f;
   
    public float speed = 1.0f;
     

    public GameObject[] blocks; // this is one row of blocks 
    public List<GameObject[]> nestedList = new List<GameObject[]>(); // this is the entire set of rows 
    public string[] letters = { "A", "Q", "F", "E", "C", "V", "P", "I", "H", "L", "Z", "X", "S", "K" , "J", "N", "M", "T"};
    string allChars = "ABCDEFGHIJKLMNOPQRSTUVWYZ";

    // public string[,] words = { {}};
    // public string[,] dangerWordss = { {}};

    public string[][] L1_block_of_words =  {
                                            new string[] {"TUFFSSETPT"}, 
                                            new string[] {"APPECOPPEE"}, 
                                            };

    public string[][] L2_block_of_words ={new string[] {"FEST"},
                                new string[] {"COPE"},
                                new string[] {"DARE"},
                                new string[] {"CAT"},
                                new string[] {"ICE"},
                                new string[] {"ABLE"},
                                new string[] {"HEAT"},
                                new string[] {"LAMP"},
                                new string[] {"BEAR"},
                                new string[] {"SILK"},
                                new string[] {"TREE"},
                                new string[] {"COW"}
                                };


    public string[][] wordsL2 ={new string[] {"FEST"}, 
                                new string[] {"COPE"}, 
                                new string[] {"DARE"}, 
                                new string[] {"CAT"}, 
                                new string[] {"ICE"}, 
                                new string[] {"ABLE"}, 
                                new string[] {"HEAT"}, 
                                new string[] {"LAMP"}, 
                                new string[] {"BEAR"}, 
                                new string[] {"SILK"} };
    public string[][] dangerWordsL2 = {
                                        new string[] {"FS", "FT", "ET"}, 
                                        new string[] {"CO","CE", "PE"}, 
                                        new string[] {"BA", "DE", "ER"}, 
                                        new string[] {"T", "AC", "TC"},
                                        new string[] {"I", "CE", "IC"}, 
                                        new string[] {"AB", "E", "EL"}, 
                                        new string[] {"H", "EA", "TA"}, 
                                        new string[] {"A", "AL","MP"}, 
                                        new string[] {"BE", "BA", "AR"}, 
                                        new string[] {"S", "IL","SI"} };
    public string[][] L2_block_of_wordsL2 =  {
                                            new string[] {"TUXFSNEMCC"},
                                            new string[] {"ZDBECOPQJJ"},
                                            new string[] {"DCARKELMKK"},
                                            new string[] {"TXAFENCKOO"},
                                            new string[] {"LCBFGHEIWW"},
                                            new string[] {"AIKLEOZNPP"},
                                            new string[] {"TUOBAHZEDD"},
                                            new string[] {"DMCPLAZHQQ"},
                                            new string[] {"ABAXRIZEUU"},
                                            new string[] {"AVLKEIZSII"},
                                            new string[] {"RBEALTZERR"},
                                            new string[] {"BNCRTODWDD"}
                                             };



    public string[][] block_of_wordsL2 =  {
                                            new string[] {"TUFFSSETZT"}, 
                                            new string[] {"ZPPECOPPEE"}, 
                                            new string[] {"DBARDERRRZ"}, 
                                            new string[] {"TTZTTACACT"}, 
                                            new string[] {"ICEIIIEIZE"}, 
                                            new string[] {"ABABLLZLLE"}, 
                                            new string[] {"HEAHHHZHTA"}, 
                                            new string[] {"AZALMPMPAM"}, 
                                            new string[] {"BEBEBAARAZ"}, 
                                            new string[] {"ZSSSSILKIL"} };

    public string[][] block_of_wordsL3 =  {
                                             new string[] {"TUXJSNAMTY"},
                                            new string[] {"ZABSCOPQTT"},
                                            new string[] {"HCARKYLMTT"},
                                            new string[] {"LOBFSHEWTT"},
                                            new string[] {"WIKLEOZNTT"},
                                            new string[] {"TUINAFZETT"},
                                            new string[] {"DFCPLOZGTT"},
                                            new string[] {"ABAXLTZETT"},
                                            new string[] {"ADLKEIZTTT"},
                                            new string[] {"ADLKEIZTTT"},
                                             };


    
    public string[][] wordsL3 = {new string[] {"JAM"}, 
                                 new string[] {"SOAP"}, 
                                 new string[] {"HAY"}, 
                                 new string[] {"SHOW"}, 
                                 new string[] {"NEW"}, 
                                 new string[] {"FIN"}, 
                                 new string[] {"GOLF"}, 
                                 new string[] {"BELT"}, 
                                 new string[] {"DIET"}, 
                                 new string[] {"KIT"}
    };

    

    public string[][] dangerWordsL3 = { 
                                       new string[]  {"AU"}, 
                                       new string[] {"ZBA"}, 
                                       new string[] {"HC"}, 
                                      new string[] {"LOB"}, 
                                       new string[] {"NO"}, 
                                       new string[] {"F"}, 
                                       new string[] {"GZ"}, 
                                       new string[] {"T"}, 
                                       new string[] {"DE"}, 
                                       new string[] {"K"} 
    };
    public string[][] L4_block_of_wordsL4 =  {
                                            new string[] {"FIUCOSREVF"},
                                            new string[] {"KRARKCPEFD"},
                                            new string[] {"PLOVKEEEVC"},
                                            new string[] {"PXRGNIECAA"},
                                            new string[] {"EXMMELPSIS"},
                                            new string[] {"GLIOWQZWOA"},
                                            new string[] {"DPLOXMDKSI"},
                                            new string[] {"RCOAEDPOLE"},
                                            new string[] {"ADLKETZTII"},
                                            new string[] {"BBPIUYZSOM"},
                                             };
    public string[][] L4_wordsL4 = {new string[] {"FOUR"},
                                    new string[] {"DARK"},
                                    new string[] {"KEEP"},
                                 new string[] {"RING"},
                                 new string[] {"MISS"},
                                 new string[] {"GOAL"},
                                 new string[] {"DISK"},
                                 new string[] {"READ"},
                                 new string[] {"DIET"},
                                 new string[] {"BOMB"}
    };
    public string[][] L4_dangerWordsL4 = {
                                       new string[]  {"OU" , "OS"},
                                       new string[] {"DA" , "EF"},
                                       new string[] {"KA" , "KC" },
                                      new string[] {"RIN", "AA"},
                                       new string[] {"EX" , "SS"},
                                       new string[] {"I" , "GL"},
                                       new string[] {"DIK" , "DX"},
                                       new string[] {"EA", "PO"},
                                       new string[] {"DA", "K"},
                                       new string[] {"BP", "BU"}
    };




    public string[][] block_of_wordsL5 = {        new string[] {"FERPOISVEI"},
                                            new string[] {"LOCURYTEWD"},
                                            new string[] {"REROPIREYT"},
                                            new string[] {"TSBMCXZWOO"},
                                            new string[] {"STROVPLSIL"},
                                            new string[] {"EAXETHROPE"},
                                            new string[] {"RDTRENRRWY"},
                                            new string[] {"ADIBIEWQXE"},
                                            new string[] {"GIPOIWDDUE"},
                                            new string[] {"FAOPLOSSMU"}};

    public string[][] wordsL5 = {

                                    new string[] {"FIVE"},
                                    new string[] { "CLOUD" },
                                    new string[] { "RETRY" },
                                    new string[] { "BOOST" },
                                    new string[] { "LIST" },
                                    new string[] { "EARTH" },
                                    new string[] { "ENTRY" },
                                    new string[] { "ABIDE" },
                                    new string[] { "GUIDE" },
                                    new string[] { "FAMOUS" } };

    public string[][] dangerWordsL5 = {
                                        new string[] {"VE", "FE", "FR"},
                                        new string[] {"CLO", "CLD", "CUO"},
                                        new string[] {"RE", "RP", "POI"},
                                        new string[] {"OO", "OST", "ZOO"},
                                        new string[] {"IST", "P", "V"},
                                        new string[] {"EAT", "EAR", "ROP"},
                                        new string[] {"TRY", "RED", "YEN"},
                                        new string[] {"BID", "Q", "XA"},
                                        new string[] {"GUI", "POD", "PIE"},
                                        new string[] { "FAM", "MU", "MOSS" } };



    public string[][] block_of_wordsL6 =  {
                                            new string[] {"CRBEAZXRAY"},
                                            new string[] {"DOLSIZOLAD"},
                                            new string[] {"SPOZCIERHA"},
                                            new string[] {"XLZKEXEART"},
                                            new string[] {"RAPQZXGEWT"},
                                            new string[] {"ELCPZRTETE"},
                                            new string[] {"CGTBORAZIT"},
                                            new string[] {"KABDEIZANR"},
                                            new string[] {"TZMOIYILEE"},
                                            new string[] {"YZTBESRLFE"} };
    public string[][] wordsL6 =
    {
                                    new string[] {"CARRY"},
                                    new string[] {"SOLID"},
                                    new string[] {"SHARP"},
                                    new string[] {"EXTRA"},
                                    new string[] {"WATER"},
                                    new string[] {"ELECT"},
                                    new string[] {"CARGO"},
                                    new string[] {"DRINK"},
                                    new string[] {"ELITE"},
                                    new string[] {"FLYER"}
    };
    public string[][] dangerWordsL6 = {
                                        new string[] {"CAB", "CAR", "RY"},
                                        new string[] {"SOIL", "LID", "SAD"},
                                        new string[] {"PAR", "SIP", "SHO"},
                                        new string[] {"EX", "RAT", "TAX"},
                                        new string[] {"GET", "WE", "EAT"},
                                        new string[] {"PR", "EC", "PEL"},
                                        new string[] {"CAT", "CAR", "RIG"},
                                        new string[] {"INK", "DIN", "RIN"},
                                        new string[] {"LIT", "LIE", "LEE"},
                                        new string[] {"FLY", "LES", "YET"} };

    public string[][] block_of_wordsL7 =  {
                                            new string[] {"NPOZICOMIT"},
                                            new string[] {"APOSXZMXIO"},
                                            new string[] {"NPZETWICEV"},
                                            new string[] {"CKAZOKEEHC"},
                                            new string[] {"FPOLIZTHIA"},
                                            new string[] {"ZSOSSETOEL"},
                                            new string[] {"ILEZOLECAD"},
                                            new string[] {"ZVDAOLVEES"},
                                            new string[] {"GEZNAPOLXR"},
                                            new string[] {"NZCPIRCKAP"} };


    public string[][] wordsL7 =
  {
                                    new string[] {"TONIC"},
                                    new string[] {"AXIOM"},
                                    new string[] {"EVENT"},
                                    new string[] {"CHECK"},
                                    new string[] {"FAITH"},
                                    new string[] {"STOLE"},
                                    new string[] {"IDEAL"},
                                    new string[] {"SAVED"},
                                    new string[] {"ANGER"},
                                    new string[] {"PANIC"}
    };
    public string[][] dangerWordsL7 = {
                                        new string[] {"ON", "TIN", "TIME"},
                                        new string[] {"MIX", "AIM", "AXIS"},
                                        new string[] {"VET", "EVEN", "TEN"},
                                        new string[] {"CC", "HACK", "KECK"},
                                        new string[] {"HAT", "FAT", "FIT"},
                                        new string[] {"LOT", "TOE", "SOLE"},
                                        new string[] {"IDEA", "EE", "LEAD"},
                                        new string[] {"SAD", "DEV", "VASE"},
                                        new string[] {"RAN", "LANE", "RAGE"},
                                        new string[] {"PIN", "NICK", "CAP"} };


    public string[][] block_of_wordsL8 =  {
                                            new string[] {"VTAZIVRSUI"},
                                            new string[] {"FREZCOELIC"},
                                            new string[] {"ABPOIMZMRE"},
                                            new string[] {"YLZICEOGUN"},
                                            new string[] {"ZSLOKEINEC"},
                                            new string[] {"TRAHZIRVEC"},
                                            new string[] {"IDPTNIZENX"},
                                            new string[] {"UETDNZITRS"},
                                            new string[] {"LAHZLELOHE"},
                                            new string[] {"EMPZICEILS"}};
    public string[][] wordsL8 =
{
                                    new string[] {"VIRUS"},
                                    new string[] {"FORCE"},
                                    new string[] {"AMBER"},
                                    new string[] {"YOUNG"},
                                    new string[] {"SINCE"},
                                    new string[] {"HEART"},
                                    new string[] {"INDEX"},
                                    new string[] {"TRUST"},
                                    new string[] {"HELLO"},
                                    new string[] {"SLIME"}
    };

    public string[][] dangerWordsL8 = {
                                        new string[] {"VIT", "RIT", "RIS"},
                                        new string[] {"FORE", "COR", "EE"},
                                        new string[] {"AB", "MEM", "RAB"},
                                        new string[] {"GUN", "YOG", "GE"},
                                        new string[] {"SIN", "INK", "EE"},
                                        new string[] {"HIR", "TRACE", "HEAR"},
                                        new string[] {"DEX", "INT", "DEN"},
                                        new string[] {"UN", "UT", "RUST"},
                                        new string[] {"LLL", "HEL", "ALO"},
                                        new string[] {"SLIM", "LIP", "SEM"} };
    public string[][] block_of_wordsL9 =  {
                                            new string[] {"VOZIVAREIP"},
                                            new string[] {"BEAEYNFUNZ"},
                                            new string[] {"UZEORGLEEA"},
                                            new string[] {"PLABSZITEL"},
                                            new string[] {"SEZTLEURYF"},
                                            new string[] {"KZOETSISME"},
                                            new string[] {"ATBOPZGNRE"},
                                            new string[] {"NLOIVRIZSG"},
                                            new string[] {"MRTRMEAZSI"},
                                            new string[] {"PARZRROTRR"} };

    public string[][] wordsL9 =
{
                                    new string[] {"VIPER"},
                                    new string[] {"FUNNY"},
                                    new string[] {"GLARE"},
                                    new string[] {"BLAST"},
                                    new string[] {"SURFY"},
                                    new string[] {"KISMET"},
                                    new string[] {"ARGENT"},
                                    new string[] {"RIVING"},
                                    new string[] {"MAREIS"},
                                    new string[] {"PARROT"}
    };

    public string[][] dangerWordsL9 = {
                                        new string[] {"VIP", "PAR", "RIP"},
                                        new string[] {"FUN", "FAN", "NAN"},
                                        new string[] {"GL", "LURE", "GOR"},
                                        new string[] {"BLA", "PLAT", "BAT"},
                                        new string[] {"SUR", "FLY", "YET"},
                                        new string[] {"KIS", "MEET", "SET"},
                                        new string[] {"ARG", "GEN", "BAR"},
                                        new string[] {"RIV", "SIV", "ROI"},
                                        new string[] {"MAR", "MEAT", "RISE"},
                                        new string[] {"POT", "RRR", "PAR"} };


    public static string[][] wordsL10 = {
                                        new string[] {"ABIDE"},
                                        new string[] {"ANVIL"}, 
                                        new string[] {"BRISK"}, 
                                        new string[] {"CLASP"} , 
                                        new string[] {"DECOR"}, 
                                        new string[]  {"FABLE"}, 
                                        new string[]  {"GLEAN"}, 
                                        new string[]  {"DEALT"}, 
                                        new string[]  {"INEPT"}, 
                                        new string[]  {"JOUST"}, 
                                        new string[]  {"MERIT"}, 
                                        new string[]  {"PLUSH"}, 
                                        new string[]  {"LURID"},
                                        new string[]  {"GIDDY"} , 
                                        new string[]  {"WINCE"},
                                    

    };
    public static string[][] dangerWordsL10 = {
                                        new string[] {"BID", "HEM", "DAD"},
                                        new string[] {"VIL", "PAN", "VAN"},
                                        new string[] {"RISK", "RIB", "SIR"},
                                        new string[] {"PLS", "CL", "BAP"},
                                        new string[] {"DEC", "ROD", "BED"},
                                        new string[] {"FAB", "ELF", "BOL"},
                                        new string[] {"LAN", "GEN", "ELG"},
                                        new string[] {"DEAL", "TEA", "EAD"},
                                        new string[] {"EPT", "IN", "TNT"},
                                        new string[] {"JOU", "OUT", "SUN"}, 
                                        new string[] {"RITE", "MIT", "REM"},
                                        new string[] {"PUSH", "FEL", "LUP"} ,
                                        new string[] {"RID", "LUD", "RUL"} ,
                                        new string[] {"GID", "YIG", "BID"} ,
                                        new string[] {"ICE", "CIR", "WIN"}  };
    public string[][] block_of_wordsL10 =  {
                                            new string[] {"IMEHBZVDDA"},
                                            new string[] {"DOPANILZVA"}, 
                                            new string[] {"IBMRSLQZKS"}, 
                                            new string[] {"ALZBAMVPCS"} , 
                                            new string[] {"OJOUDCEZBR"}, 
                                            new string[] {"AFCLEZOBLF"}, 
                                            new string[] {"WGJYLAENZN"}, 
                                            new string[] {"ZDTEORLAHA"}, 
                                            new string[] {"FFLNPIZETT"}, 
                                            new string[] {"SQTUUNJZNO"}, 
                                            new string[] {"VEEIMRZTOV"}, 
                                            new string[] {"SLHZUEPFNJ"}, 
                                            new string[] {"UGZLDIWDRW"},
                                            new string[] {"IWRZDGXDYB"} , 
                                            new string[] {"CWILENRZJV"}};
    public static string[][] wordsL11 = {
                                        new string[] {"DRAKE"},
                                        new string[] {"LEVET"},
                                        new string[] {"OWSER"},
                                        new string[] {"SMOCK"} ,
                                        new string[] {"HEAVY"},
                                        new string[]  {"SCARP"},
                                        new string[]  {"DROME"},
                                        new string[]  {"SHEET"},
                                        new string[]  {"ITCHY"},
                                        new string[]  {"AGIST"},
                                        new string[]  {"OXIDE"},
                                        new string[]  {"SLOPE"},
                                        new string[]  {"SMITE"},
                                        new string[]  {"INCUR"} ,
                                        new string[]  {"CALYX"},


    };
    public static string[][] dangerWordsL11 = {
                                        new string[] {"ARK", "DAKE", "ARD"},
                                        new string[] {"VEL", "TEL", "TAL"},
                                        new string[] {"OWE", "OUR", "SOW"},
                                        new string[] {"MOCK", "SOCK", "COMS"},
                                        new string[] {"EAVY", "HE", "FAKE"},
                                        new string[] {"CARP", "ACS", "SID"},
                                        new string[] {"ROME", "D", "JOE"},
                                        new string[] {"SHE", "TEE", "EEE"},
                                        new string[] {"YET", "HIT", "CIT"},
                                        new string[] {"SIT", "SAT", "AGI"},
                                        new string[] {"OX", "EOD", "IDE"},
                                        new string[] {"LOPE", "LOPS", "BOLE"} ,
                                        new string[] {"MITE", "SIM", "DIM"} ,
                                        new string[] {"CUR", "UNI", "CIN"} ,
                                        new string[] {"CAL", "XAL", "FAY"}  };
    public string[][] block_of_wordsL11 =  {
                                            new string[] {"XEZHARKDRH"},
                                            new string[] {"ALSLJEVTEZ"},
                                            new string[] {"JZYENOURSW"},
                                            new string[] {"OECMKYZGSY"} ,
                                            new string[] {"EYKZAVFHWF"},
                                            new string[] {"CIFSDPZARF"},
                                            new string[] {"MDJPEHSRZO"},
                                            new string[] {"GTSEEYIEZH"},
                                            new string[] {"TYHEBCIVZT"},
                                            new string[] {"AATSWGJBZI"},
                                            new string[] {"OGKDXIVEVZ"},
                                            new string[] {"CPTZSPLBOE"},
                                            new string[] {"EBKUTZSIDM"},
                                            new string[] {"BNHUIRZCXS"} ,
                                            new string[] {"LYCFFASXZL"}};
    public static string[][] wordsL12 = {
                                        new string[] {"TEASE"},
                                        new string[] {"FAGOT"},
                                        new string[] {"PATTY"},
                                        new string[] {"MOMOT"} ,
                                        new string[] {"SWISH"},
                                        new string[]  {"DROPT"},
                                        new string[]  {"BRIDE"},
                                        new string[]  {"CORVE"},
                                        new string[]  {"INURN"},
                                        new string[]  {"LAPSE"},
                                        new string[]  {"VIVID"},
                                        new string[]  {"CHILL"},
                                        new string[]  {"CAIRN"},
                                        new string[]  {"FEASE"} ,
                                        new string[]  {"MOUND"},


    };
    public static string[][] dangerWordsL12 = {
                                        new string[] {"TEA", "EAE", "RED"},
                                        new string[] {"FAT", "GOT", "DOG"},
                                        new string[] {"TAT", "TTY", "PAY"},
                                        new string[] {"MOO", "MOM", "DOM"},
                                        new string[] {"SWIS", "WHIS", "BIS"},
                                        new string[] {"DROP", "POT", "YOG"},
                                        new string[] {"RIDE", "BIE", "BIDE"},
                                        new string[] {"CORE", "POR", "VOR"},
                                        new string[] {"IN", "NURN", "JR"},
                                        new string[] {"LAP", "APE", "SAP"},
                                        new string[] {"VID", "VIVI", "VIL"},
                                        new string[] {"HILL", "CHI", "KID"} ,
                                        new string[] {"CIN", "RIN", "CAN"} ,
                                        new string[] {"EASE", "FAS", "YEA"} ,
                                        new string[] {"NOD", "NOT", "MOND"}  };
    public string[][] block_of_wordsL12 =  {
                                            new string[] {"ZAEERDSTSR"},
                                            new string[] {"AOLLTUZFGD"},
                                            new string[] {"PETXZYARNT"},
                                            new string[] {"ISZTHOMOMD"} ,
                                            new string[] {"SZWRHISBGI"},
                                            new string[] {"POGYTIZLDR"},
                                            new string[] {"VIADELRPZB"},
                                            new string[] {"EJZOPCVRLV"},
                                            new string[] {"NDIRUZJRRN"},
                                            new string[] {"ESLSAZPEBF"},
                                            new string[] {"WIBLLDZVVI"},
                                            new string[] {"ZILKLCIHDX"},
                                            new string[] {"JZKIRCANMC"},
                                            new string[] {"ZSMMEFCYEA"} ,
                                            new string[] {"MZONKMOTDU"}};
    public static string[][] wordsL13 = {
                                        new string[] {"MARKET"},
                                        new string[] {"PRISMY"},
                                        new string[] {"SKETCH"},
                                        new string[] {"CONVOY"} ,
                                        new string[] {"EMPARK"},
                                        new string[]  {"CAMLET"},
                                        new string[]  {"SQUASH"},
                                        new string[]  {"DECAMP"},
                                        new string[]  {"ASPIRE"},
                                        new string[]  {"BLOWSE"},
                                        new string[]  {"EXCISE"},



    };
    public static string[][] dangerWordsL13 = {
                                        new string[] {"Q", "X", "V"},
                                        new string[] {"Q", "X", "V"},
                                        new string[] {"Q", "X", "V"},
                                        new string[] {"Q", "X", "G"},
                                        new string[] {"Q", "X", "V"},
                                        new string[] {"Q", "X", "V"},
                                        new string[] {"G", "X", "V"},
                                        new string[] {"Q", "X", "V"},
                                        new string[] {"Q", "X", "V"},
                                        new string[] {"Q", "X", "V"},
                                        new string[] {"Q", "G", "V"} };

    public string[][] block_of_wordsL13 =  {
                                            new string[] {"TRAVMXKZEQ"},
                                            new string[] {"VSQRZMXIPY"},
                                            new string[] {"ZCQHVESTXK"},
                                            new string[] {"GOVZCOYQNX"} ,
                                            new string[] {"AVREPMXKQZ"},
                                            new string[] {"TAXMCLVQEZ"},
                                            new string[] {"SXZAUQVSGH"},
                                            new string[] {"PDQZMCXEVA"},
                                            new string[] {"RZQSXAEPVI"},
                                            new string[] {"BOQWZELXVS"},
                                            new string[] {"CZGXEQIEVS"} };
  
    public static string[][] wordsL14 = {
                                        new string[] {"ETYMIC"},
                                        new string[] {"THRILL"},
                                        new string[] {"OUTSET"},
                                        new string[] {"DEPEND"} ,
                                        new string[] {"COILED"},
                                        new string[]  {"ATTEST"},
                                        new string[]  {"ONRUSH"},
                                        new string[]  {"ENCAGE"},
                                        new string[]  {"STAPLE"},
                                        new string[]  {"TWITCH"},
                                        new string[]  {"MUSCAT"},
                                        new string[]  {"UNIATE"},
                                        new string[]  {"DEPART"},
                                        new string[]  {"RAFFLE"} ,
                                        new string[]  {"CARPER"},


    };
    public static string[][] dangerWordsL14 = {
                                        new string[] {"MIC", "ETY", "EPIC"},
                                        new string[] {"RILL", "HILL", "TIRL"},
                                        new string[] {"OUT", "SUT", "TEST"},
                                        new string[] {"END", "DEPE", "EEE"},
                                        new string[] {"COIL", "LED", "COD"},
                                        new string[] {"ATT", "TES", "MAT"},
                                        new string[] {"RUSH", "OURS", "ON"},
                                        new string[] {"CAG", "CEN", "BAT"},
                                        new string[] {"PATS", "PALE", "SALE"},
                                        new string[] {"TWIT", "ITCH", "T"},
                                        new string[] {"MUS", "CATS", "POC"},
                                        new string[] {"PAT", "UNI", "EAT"} ,
                                        new string[] {"PEAR", "DEP", "REAT"} ,
                                        new string[] {"BALD", "LED", "RAF"} ,
                                        new string[] {"CARP", "REAR", "WAP"}  };
    public string[][] block_of_wordsL14 =  {
                                            new string[] {"CYIEVTPMTZ"},
                                            new string[] {"LIFLDZHBRT"},
                                            new string[] {"OZTPESUPKT"},
                                            new string[] {"CENDPOZEED"} ,
                                            new string[] {"OBEIZLGDCT"},
                                            new string[] {"MATSETTOZC"},
                                            new string[] {"NZRNSNORHU"},
                                            new string[] {"QGZEAECBTN"},
                                            new string[] {"ATVPVESLCZ"},
                                            new string[] {"ZHCWIQRUTT"},
                                            new string[] {"ZCOPUASTUM"},
                                            new string[] {"NEIATNZUFP"},
                                            new string[] {"RETAPBATDZ"},
                                            new string[] {"BWFDLAZRFE"} ,
                                            new string[] {"ZECYRPOAWR"}};
    public static string[][] wordsL15 = {
                                        new string[] {"UNVEIL"},
                                        new string[] {"FISCAL"},
                                        new string[] {"RAMIFY"},
                                        new string[] {"PROMPT"} ,
                                        new string[] {"LAMENT"},
                                        new string[]  {"CANDID"},
                                        new string[]  {"AVENUE"},
                                        new string[]  {"ORNATE"},
                                        new string[]  {"SUBTLE"},
                                        new string[]  {"NUANCE"},
                                        new string[]  {"INCITE"},
                                        new string[]  {"REFUTE"},
                                        new string[]  {"DISMAY"},
                                        new string[]  {"PERISH"} ,
                                        new string[]  {"STATIC"},


    };
    public static string[][] dangerWordsL15 = {
                                        new string[] {"VEIL", "UN", "LEV"},
                                        new string[] {"FAS", "IFS", "LAS"},
                                        new string[] {"OAK", "RAM", "FARM"},
                                        new string[] {"ROM", "PORK", "DOT"},
                                        new string[] {"LAME", "AMEN","MM"},
                                        new string[] {"CAN", "INT", "DAD"},
                                        new string[] {"VAN", "VEN", "VUN"},
                                        new string[] {"NOR", "NATE", "NOT"},
                                        new string[] {"BUS", "FEB", "BLE"},
                                        new string[] {"ANUT", "ACE", "UNCE"},
                                        new string[] {"CITE", "CIN", "NIG"},
                                        new string[] {"FUTE", "RETH", "FER"} ,
                                        new string[] {"MAY", "SIAM", "SID"} ,
                                        new string[] {"PER", "PISH", "RISH"} ,
                                        new string[] {"CIT", "SAT", "FATS"}  };
    public string[][] block_of_wordsL15 =  {
                                            new string[] {"LEKMHNUVZI"},
                                            new string[] {"FFBLZSAILC"},
                                            new string[] {"RFOAKIDMYZ"},
                                            new string[] {"POPKRPZMDT"} ,
                                            new string[] {"TLAEVTMMZN"},
                                            new string[] {"INTZAICDBD"},
                                            new string[] {"TAEVNIFUEZ"},
                                            new string[] {"WEROXTZNIA"},
                                            new string[] {"EFVISLZBTU"},
                                            new string[] {"ANAEDUZCTN"},
                                            new string[] {"IMECZIVNGT"},
                                            new string[] {"ZTHFERLUEJ"},
                                            new string[] {"SZMLIQDRAY"},
                                            new string[] {"SHECRVPPZI"} ,
                                            new string[] {"ZIOACTATFS"}};
    public static string[][] wordsL1 = {new string[] {"BOLD"},
                                        new string[] {"DALE"}, 
                                        new string[] {"MAP"}, 
                                        new string[] {"DENT"} , 
                                        new string[] {"BLUE"}, 
                                        new string[]  {"BIN"}, 
                                        new string[]  {"BRO"}, 
                                        new string[]  {"MAT"}, 
                                        new string[]  {"FIND"}, 
                                        new string[]  {"MAD"}, 
                                        new string[]  {"HIP"}, 
                                        new string[]  {"PINK"}, 
                                        new string[]  {"RED"},
                                        new string[]  {"FIX"} , 
                                        new string[]  {"BALD"} };
    public static string[][] dangerWordsL1 = {new string[] {"FO"},
                                             new string[]  {"DA"}, 
                                             new string[]  {"P"},
                                             new string[] {"MP"}, 
                                             new string[] {"D"},
                                             new string[]  {"IN"}, 
                                             new string[] {"O"}, 
                                             new string[] {"A"}, 
                                             new string[] {"MI"}, 
                                             new string[] {"D"}, 
                                             new string[] {"P"},  
                                             new string[] {"INK"},
                                             new string[]  {"ED"}, 
                                             new string[] {"I"}, 
                                             new string[] {"BA"}};
    public static string[][] wordsLfun = {
                                        new string[] {"MANGO"},
                                        new string[] {"PEACH"}, 
                                        new string[] {"KIWI"}, 
                                        new string[] {"BANANA"} , 
                                        new string[] {"GUAVA"}, 
                                        new string[]  {"GRAPE"}, 
                                        new string[]  {"FIG"}, 
                                        new string[]  {"PAPAYA"}, 
                                        new string[]  {"APRICOT"}, 
                                        new string[]  {"MELON"}, 
                                        

    };
    public static string[][] dangerWordsLfun = {
                                        new string[] {"MAN", "AN", "GO"},
                                        new string[] {"ACH", "PE", "EACH"},
                                        new string[] {"I", "KI", "IWI"},
                                        new string[] {"AN", "ANA", "B"},
                                        new string[] {"G", "UVA", "A"},
                                        new string[] {"GE", "RAP", "R"},
                                        new string[] {"F", "FI", "G"},
                                        new string[] {"A", "Y", "PAYA"},
                                        new string[] {"RTI", "CO", "AP"},
                                        new string[] {"LE", "M", "ON"},
                                         };
    public string[][] block_of_wordsLfun =  {
                                            new string[] {"LLMMGOANZR"},
                                            new string[] {"PAEAZCHHHL"}, 
                                            new string[] {"IIIKISKKWZ"}, 
                                            new string[] {"ZBANANAMGS"} , 
                                            new string[] {"AAAGUAVAZU"}, 
                                            new string[] {"RAPRAPRZGE"}, 
                                            new string[] {"GGZIFFIIGG"}, 
                                            new string[] {"PAPAPAYAZP"}, 
                                            new string[] {"AZAPOCIRNT"}, 
                                            new string[] {"MELONMELZN"}, 
                                            };
    public string[][] facts_Lfun =  {
                                            new string[] {"considered as the king of fruits."},
                                            new string[] {"member of the rose family"}, 
                                            new string[] {"were originally known as Chinese gooseberries."}, 
                                            new string[] {"great source of potassium"} , 
                                            new string[] {"leaves are commonly used in traditional medicine"}, 
                                            new string[] {"Use in winemaking"}, 
                                            new string[] {"Excellent source of dietary fiber"}, 
                                            new string[] {"rich in enzymes called papain and chymopapain"}, 
                                            new string[] {"believed to have anti-inflammatory properties."}, 
                                            new string[] {"refreshing on a hot summer day"}, 
                                            };
    public string[][] words = wordsL1;
    public string[][] facts = wordsL1;
    public string[][] dangerWordss = dangerWordsL1;
    // Start is called before the first frame update
    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "L2")

        {
            Debug.Log("0000000000111111111");
            words = L2_block_of_words;
            //blocks_row_count = L2_block_of_words.Length;
        }

    }
    void Start()
    {
           //10 blocks in a row
        float width = 1;
        float offset = 0.1f;
        float blockScale = 1.5f;

        Scene scene = SceneManager.GetActiveScene();

        if(scene.name == "LevelOne")
        {  Debug.Log("here");
            words = wordsL1;
            dangerWordss = dangerWordsL1;
        }
        else if (scene.name == "LevelTwo")
        {
            words = wordsL2;
            dangerWordss = dangerWordsL2;
        }
        else if (scene.name == "LevelThree")
        {
            words = wordsL3;
            dangerWordss = dangerWordsL3;
        }
        else if (scene.name == "LevelFour")
        {
            //words = wordsL4;
            //dangerWordss = dangerWordsL4;
        }
        int blocks_row_count = words.Length;
         if(scene.name == "L1")
         {
            blocks_row_count=L1_block_of_words.Length;
         }

        if (scene.name == "L2")

        {
            
            words = L2_block_of_words;
            blocks_row_count = L2_block_of_words.Length;
        }

        if(scene.name == "L3")
        {
            Debug.Log("0000000000");
            blocks_row_count = wordsL3.Length;
            words = wordsL3;
            dangerWordss = dangerWordsL3;
        }

        if(scene.name == "L4")
        {
            blocks_row_count = L4_wordsL4.Length;
            words = L4_wordsL4;
            dangerWordss = L4_dangerWordsL4;
        }

        if(scene.name== "L5")
        {
            blocks_row_count = wordsL5.Length;
            words = wordsL5;
            dangerWordss = dangerWordsL5;
        }

        if (scene.name == "L6")
        {
            blocks_row_count = wordsL6.Length;
            words = wordsL6;
            dangerWordss = dangerWordsL6;
        }

        if (scene.name == "L7")
        {
            blocks_row_count = wordsL7.Length;
            words = wordsL7;
            dangerWordss = dangerWordsL7;
        }

        if (scene.name == "L8")
        {
            blocks_row_count = wordsL8.Length;
            words = wordsL8;
            dangerWordss = dangerWordsL8;
        }

        if (scene.name == "L9")
        {
            blocks_row_count = wordsL9.Length;
            words = wordsL9;
            dangerWordss = dangerWordsL9;
        }
        if (scene.name == "L10")
        {
            blocks_row_count = wordsL10.Length;
            words = wordsL10;
            dangerWordss = dangerWordsL10;
        }
        if (scene.name == "L11")
        {
            blocks_row_count = wordsL11.Length;
            words = wordsL11;
            dangerWordss = dangerWordsL11;
        }
        if (scene.name == "L12")
        {
            blocks_row_count = wordsL12.Length;
            words = wordsL12;
            dangerWordss = dangerWordsL12;
        }
        if (scene.name == "L13")
        {
            blocks_row_count = wordsL13.Length;
            words = wordsL13;
            dangerWordss = dangerWordsL13;
        }
        if (scene.name == "L14")
        {
            blocks_row_count = wordsL14.Length;
            words = wordsL14;
            dangerWordss = dangerWordsL14;
        }
        if (scene.name == "L15")
        {
            blocks_row_count = wordsL15.Length;
            words = wordsL15;
            dangerWordss = dangerWordsL15;
        }
        if (scene.name == "Lfun")
        {
            blocks_row_count = wordsLfun.Length;
            words = wordsLfun;
            dangerWordss = dangerWordsLfun;
            facts = facts_Lfun;
        }

        for (int j = 0; j < blocks_row_count; j++) // this is for the total number of rows
        {
            
            
            blocks = new GameObject[10];
            if (j == 0)
            {
                Debug.Log("j is 0");

            }
            string word = words[j][0];
            var shuffledString="AAAAAAAAAA";
            string dangerword = dangerWordss[j][0];
            if (scene.name == "LevelTwo")
            {   
                shuffledString = block_of_wordsL2[j][0];
            }
            else if(scene.name == "LevelThree")
            {
                shuffledString = block_of_wordsL3[j][0];
            }
            
            else if(scene.name == "LevelFour")
            {
                shuffledString = block_of_wordsL5[j][0];
            }
            else if(scene.name == "L1")
            {
                shuffledString = L1_block_of_words[j][0];
            }
            else if(scene.name== "L2")
            {
                shuffledString = L2_block_of_wordsL2[j][0];
            }
            else if(scene.name == "L3")
            {
                shuffledString = block_of_wordsL3[j][0];
            }
            else if(scene.name == "L4")
            {
                shuffledString = L4_block_of_wordsL4[j][0];
            }
            else if(scene.name == "L5")
            {
                shuffledString = block_of_wordsL5[j][0];
            }else if (scene.name == "L6")
            {
                shuffledString = block_of_wordsL6[j][0];
            }
            else if (scene.name == "L7")
            {
                shuffledString = block_of_wordsL7[j][0];
            }
            else if (scene.name == "L8")
            {
                shuffledString = block_of_wordsL8[j][0];
            }
            else if (scene.name == "L9")
            {
                shuffledString = block_of_wordsL9[j][0];
            }
            else if (scene.name == "L10")
            {
                shuffledString = block_of_wordsL10[j][0];
            }
            else if (scene.name == "L11")
            {
                shuffledString = block_of_wordsL11[j][0];
            }
            else if (scene.name == "L12")
            {
                shuffledString = block_of_wordsL12[j][0];
            }
            else if (scene.name == "L13")
            {
                shuffledString = block_of_wordsL13[j][0];
            }
            else if (scene.name == "L14")
            {
                shuffledString = block_of_wordsL14[j][0];
            }
            else if (scene.name == "L15")
            {
                shuffledString = block_of_wordsL15[j][0];
            }
            else if (scene.name == "Lfun")
            {
                shuffledString = block_of_wordsLfun[j][0];
            }
            else
            {
                HashSet<Char> hs = new HashSet<Char>();
            foreach (char c in word)
            {
                hs.Add(c);
            }
            foreach(char c in dangerword)
            {
                hs.Add(c);
            }
            // foreach(char c in dangerword)
            // {
            //     hs.Add(c);
            // }
            // Debug.Log("WORD: " + word);
            int numOfRandomLetters = 10 - hs.Count;
            string randomLetters = generateRandomLetters(numOfRandomLetters);
            string shuffleLetters = "";
            string finalWord = string.Join("", hs.ToArray());
            shuffleLetters += randomLetters + finalWord;

            shuffledString = shuffleAllLetters(shuffleLetters);}
            
            // char[] shuffledString1 = block_of_words[j].ToCharArray();
            float posy = transform.position.y + 1.1f * j*blockScale; // this is for making the rows come one below the other
            for (int i = 0; i < 10; i++) // this is for the 10 blocks in a single row 
            {
                GameObject block = Instantiate(blockPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                // block.transform.position = new Vector3(transform.position.x + (i * width) + (i * offset), posy, 0);
                block.transform.position = new Vector3(transform.position.x + (i * width*blockScale) + (i * offset*blockScale), posy, 0);
                block.GetComponentInChildren<TextMesh>().fontSize = 18; 
                block.GetComponentInChildren<TextMesh>().characterSize = 0.5F;
                block.GetComponentInChildren<TextMesh>().alignment = TextAlignment.Right;
                block.GetComponentInChildren<TextMesh>().text = Char.ToString(shuffledString[i]);               
                blocks[i] = block;

            }
            nestedList.Add(blocks);
        }
    }

    // Update is called once per frame  
    void Update()
    {
        
    }

    public string shuffleAllLetters(string str)
    {

        char[] charArray = str.ToCharArray();

        // Shuffle the array of characters
        System.Random random = new System.Random();
        charArray = charArray.OrderBy(x => random.Next()).ToArray();

        // Convert the shuffled array of characters back to a string
        string shuffledString = new string(charArray);
        // Debug.Log("Shuffled String: " + shuffledString);

        return shuffledString;
    }

    public string generateRandomLetters(int n)
    {
        //char[] randomLetters = new char[n];
        string allCharsTemp = allChars;
        string randomChar = "";

        for (int i = 0; i < n; i++)
        {
            int index = UnityEngine.Random.Range(0, allCharsTemp.Length);
            char chr = allCharsTemp[index];
            // Debug.Log("Random letter: " + chr);
            randomChar += Char.ToString(chr);
            allCharsTemp.Remove(index);
        }

        //return randomLetters;
        // Debug.Log("randomletter str: " + randomChar);
        return randomChar;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("*****");
    }

}

