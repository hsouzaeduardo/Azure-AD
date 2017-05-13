# Azure-AD

Henrique Souza
https://www.linkedin.com/in/hsouzaeduardo/
hsouza.eduardo@gmail.com
hsouza.eduardo@outlook.com


https://itextpad.com/kas20532

https://1drv.ms/f/s!AvNLjEQvbyJ8m1BLwe6nlOvJDTcB


/*--------------------------------------------------------------------------*/
/* Best practices for windows azure */
https://docs.microsoft.com/en-us/azure/architecture/best-practices/naming-conventions

Retry Police
https://github.com/dotnet-architecture/eShopOnContainers

https://docs.docker.com/engine/reference/commandline/run/ 

https://github.com/App-vNext/Polly

https://github.com/simplcommerce 

https://blogs.msdn.microsoft.com/cesardelatorre/2014/11/30/myshuttle-biz-demo-apps-from-connect-visual-studio-and-azure-event/

https://github.com/Azure/azure-sdk-for-net/tree/Fluent

Hub de notificações free
https://onesignal.com/ 

https://login.windows.net/hsouzaeduardo81outlook.onmicrosoft.com/.well-known/openid-configuration

/*--------------------------------------------------------------------------*/
Inbound network port 3389 Rule for RDP
Inbound network port 80 Rule for WWW

$nsgRuleRDP = New-AzureRmNetworkSecurityRuleConfig -Name myNetworkSecurityGroupRuleRDP  -Protocol Tcp 
    -Direction Inbound -Priority 1000 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * `
    -DestinationPortRange 3389 -Access Allow

$nsgRuleWeb = New-AzureRmNetworkSecurityRuleConfig -Name myNetworkSecurityGroupRuleWWW  -Protocol Tcp `
    -Direction Inbound -Priority 1001 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * `
    -DestinationPortRange 80 -Access Allow

$nsg = New-AzureRmNetworkSecurityGroup -ResourceGroupName myResourceGroup -Location EastUS `
    -Name myNetworkSecurityGroup -SecurityRules $nsgRuleRDP,$nsgRuleWeb

# Define a credential object
$cred = Get-Credential

# Create a virtual machine configuration
$vmConfig = New-AzureRmVMConfig -VMName myVM -VMSize Standard_DS2 | `
    Set-AzureRmVMOperatingSystem -Windows -ComputerName myVM -Credential $cred | `
    Set-AzureRmVMSourceImage -PublisherName MicrosoftWindowsServer -Offer WindowsServer `
    -Skus 2016-Datacenter -Version latest | Add-AzureRmVMNetworkInterface -Id $nic.Id


New-AzureRmVM -ResourceGroupName myResourceGroup -Location EastUS -VM $vmConfig
