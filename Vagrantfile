Vagrant.configure("2") do |config|
  config.vm.box = "ubuntu/trusty64"
  config.vm.network "private_network", ip: "192.168.50.4"
  config.vm.provision "shell", run: "always", inline: <<-SHELL
    cd /
    wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.asc.gpg
    sudo mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/
    wget -q https://packages.microsoft.com/config/ubuntu/18.04/prod.list 
    sudo mv prod.list /etc/apt/sources.list.d/microsoft-prod.list
    sudo chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg
    sudo chown root:root /etc/apt/sources.list.d/microsoft-prod.list
    sudo apt-get install apt-transport-https
    sudo apt-get update
    sudo apt-get -y install aspnetcore-runtime-2.2
    sudo apt-get -y install dotnet-sdk-2.2
    cd /vagrant/src/WebApi
    echo "Dotnet başlatılıyor."
    dotnet run
  SHELL
end