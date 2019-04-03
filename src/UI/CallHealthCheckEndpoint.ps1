$server = "$env:AppUrl"
$uri = "$server/healthcheck"

Write-Host "Smoke testing $env:AppUrl"

Invoke-WebRequest $uri -UseBasicParsing | Foreach {
    $_.Content.Contains("Success") | Foreach {
        if(-Not($_)) {
            Throw "Web smoke test failed"
        }
        else {
            Write-Host "Web smoke test passed."
        }
    }
}