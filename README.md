# Esercizio 1 - C#

Questo repository contiene il codice sorgente per **Esercizio 1** sviluppato in C#, utilizzando .NET 8.

## Descrizione
Questo progetto è un esercizio introduttivo per acquisire le basi di C# e del framework .NET. L'obiettivo è comprendere i fondamenti della programmazione in C# partendo dalle tecnologie più legacy, esplorando concetti fondamentali che costituiscono la base per lo sviluppo moderno con .NET.

Include esercizi pratici per familiarizzare con:

- Strutture di base del linguaggio C#
- Creazione di classi e metodi
- Gestione degli input e output
- Utilizzo di collezioni e cicli
- Struttura di un progetto .NET

## Requisiti
Per eseguire il progetto, è necessario avere installati:

- [**.NET 8 SDK**](https://dotnet.microsoft.com/download/dotnet/8.0)
- Un IDE compatibile con .NET, come [Visual Studio](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/)
- **PostgreSQL**, in esecuzione sul tuo sistema (se richiesto dalle funzionalità del progetto)

## Configurazione del Database e della Connection String
Il progetto richiede l'utilizzo di un database **PostgreSQL** per funzionare correttamente. Per configurare la **connection string**:

1. **Installa** e avvia il tuo server PostgreSQL.
2. Nella **cartella principale del progetto**, crea un file denominato `.env` (se non esiste già).
3. All'interno del file `.env`, inserisci la tua connection string. Ad esempio:
   ```env
   ConnectionStrings__DefaultConnection=Host=localhost;Port=5432;Database=NomeTuoDatabase;Username=nomeUtente;Password=tuaPassword
   ```
   Assicurati di sostituire i valori con quelli appropriati per il tuo ambiente.

> È importante non includere file contenenti credenziali sensibili in un repository pubblico. Assicurati che `.env` sia inserito nel tuo `.gitignore`.

## Installazione

1. Clona questo repository sul tuo computer:
   ```bash
   git clone https://github.com/oBeta97/esercizio-1-c-.git
   ```
2. Accedi alla directory del progetto:
   ```bash
   cd esercizio-1-c-
   ```
3. Apri il progetto con il tuo IDE preferito.
4. Ripristina i pacchetti necessari (se richiesto):
   ```bash
   dotnet restore
   ```

## Esecuzione

Per eseguire l'applicazione:

1. Assicurati di essere nella directory principale del progetto.
2. (Facoltativo) Se è presente la funzionalità di migrazione, esegui:
   ```bash
   dotnet ef database update
   ```
3. Esegui l'applicazione con il comando:
   ```bash
   dotnet run
   ```

## Struttura del Progetto
Il progetto segue la struttura standard di un'applicazione .NET:

- **Program.cs**: Punto di ingresso dell'applicazione.
- **Models/**: Contiene le classi utilizzate per modellare i dati.
- **Services/**: Contiene la logica di business.
- **Utilities/**: Contiene metodi di supporto e funzioni utili.

## Contributi
Se desideri contribuire al progetto:

1. Fai un fork del repository.
2. Crea un branch per la tua feature:
   ```bash
   git checkout -b nome-feature
   ```
3. Effettua le modifiche e fai un commit:
   ```bash
   git commit -m "Descrizione delle modifiche"
   ```
4. Invia una pull request al branch principale.

## Licenza
Questo progetto è distribuito sotto la licenza MIT. Consulta il file [LICENSE](./LICENSE) per ulteriori dettagli.

---

Se hai domande o suggerimenti, sentiti libero di aprire una [issue](https://github.com/oBeta97/esercizio-1-c-/issues) o contattarmi direttamente!

