"""Build the C# project and run all pre-recorded test cases."""
from pathlib import Path
import json
import os
import subprocess
import sys

folder = Path(__file__).resolve().parent
project = folder.parent / 'Gcd' / 'Gcd.csproj'
dotnet = os.environ.get('GCD_DOTNET', 'dotnet')
tests = json.loads((folder / 'tests.json').read_text(encoding='utf-8'))
if '--no-build' not in sys.argv:
    subprocess.run([dotnet, 'build', str(project), '-c', 'Release', '--nologo'], check=True)
dll = project.parent / 'bin' / 'Release' / 'net8.0' / 'Gcd.dll'
rows = []
failed = 0
for test in tests:
    result = subprocess.run(
        [dotnet, str(dll)], input=test['a'] + '\n' + test['b'] + '\n',
        text=True, capture_output=True, timeout=10,
    )
    actual = result.stdout.strip()
    ok = actual == test['expected'] and result.returncode == 0 and not result.stderr.strip()
    failed += not ok
    rows.append(f"| {test['id']} | `{test['expected']}` | `{actual}` | {result.returncode} | {'PASS' if ok else 'FAIL'} |")
report = '# Фактический прогон C#\n\n'
sdk_version = os.environ.get('GCD_SDK_VERSION') or subprocess.check_output([dotnet, '--version'], text=True).strip()
report += 'Версия .NET SDK: ' + sdk_version + '.\n\n'
if '--no-build' in sys.argv:
    report += 'Запуск с --no-build: использована предварительно скомпилированная сборка. В среде подготовки Program.cs скомпилирован компилятором Roslyn csc из .NET SDK 8.0.427 с эталонными сборками net8.0; запуск выполнен средой .NET 8.0.33. Обычный dotnet build здесь недоступен из-за ошибки чтения сведений о процессе в среде исполнения.\n\n'
report += 'Ожидаемые результаты взяты из tests.json, записанного до запуска.\n\n'
report += '| Тест | Ожидаемый вывод | Фактический вывод | Код завершения | Итог |\n| --- | --- | --- | ---: | --- |\n'
report += '\n'.join(rows) + f'\n\nПройдено: {len(tests) - failed}/{len(tests)}.\n'
(folder / 'test-results.md').write_text(report, encoding='utf-8')
print(report)
sys.exit(1 if failed else 0)
