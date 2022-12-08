

chmod +x api-build.sh
chmod +x frontend-build.sh


echo "Building Docker Images"


sh api-build.sh
sh frontend-build.sh