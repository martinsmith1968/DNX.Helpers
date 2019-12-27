APPNAME=$1
NUGET_API_URL=$2
NUGET_API_KEY=$3

echo nuget push $APPNAME.*.nupkg -Source $NUGET_API_URL -ApiKey secret
nuget push $APPNAME.*.nupkg -Source $NUGET_API_URL -ApiKey $NUGET_API_KEY
