![image](https://github.com/danilt2000/AcmarkInvalidDocumentsLoader/assets/75219332/332d5ca6-a6ed-4c70-ac28-fdf2ac8f9c12)



<h1>Zadání úkolu</h1>
Na webu MV ČR (http://aplikace.mvcr.cz/neplatne-doklady/) je k dispozici databáze neplatných 
dokladů ve formátu zazipovaných CSV souborů, kterou je potřeba zpracovat a naimportovat do CRM.

Databáze sestává z několika oddělených souborů – nové OP, staré OP, fialové CP, zelené CP, zbrojní 
průkazy (ty nás aktuálně nezajímají)
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
  
</head>
<body>
    <h1>Popis Projektu</h1>
    <p>
V rámci tohoto projektu jsem realizoval implementaci systému pro automatické aktualizace souborů na serveru ACMARK.
      
Tento project byl navržen a vytvořen tak, aby optimálně odpovídal potřebám Acmark, přičemž byla zajištěna maximální efektivita a spolehlivost provozu.

Projekt byl pečlivě strukturován a podroběn několika fázím testování, aby byla zajištěna jeho robustnost a správnost funkcionality. V rámci jeho vývoje byly sledovaní principy SOLID.

Nyní je projekt úspěšně dokončen a připraven k dalšímu hodnocení. 
</p>
    <h2>Nastavení automatického spuštění</h2>
    <p>
    Pro nastavení automatického spuštění aplikace v noci, stáhněte projekt, proveďte sestavení Release, poté zkopírujte projekt z adresáře bin na libovolné místo a zadejte tento příkaz:
    </p>
    <pre><code>
    schtasks /create /sc daily /tn "AcmarkDocumentLoader" /tr "C:\Path\Soubor.exe" /st 02:00
    </code></pre>
   <p>
Pro odstranění tohoto samočinného spouštění použijte tento příkaz 
</p>
   <pre><code>
  schtasks /delete /tn "AcmarkDocumentLoader" /f
    </code></pre>

V projektu byly použity následující nugets

![image](https://github.com/danilt2000/AcmarkInvalidDocumentsLoader/assets/75219332/23f8f8aa-585d-488d-be08-524fe98f0572)

     
</body>
</html>

<h1></h1>
The work was done by Danil Tkachenko

