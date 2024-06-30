resource "azurerm_resource_group" "mitigation_calculator" {
  name = "mitigation_calculator"
  location = "Switzerland North"
}

resource "azurerm_container_app" "example" {
  name                         = "example-app"
  container_app_environment_id = var.container_app_environment_id
  resource_group_name          = azurerm_resource_group.mitigation_calculator.name
  revision_mode                = "Single"

  template {
    container {
      name   = "mitigationcalculator"
      image  = "ghcr.io/lumi1986/stfc.mitigationcalculator:main"
      cpu    = 0.25
      memory = "0.5Gi"
    }
  }
}