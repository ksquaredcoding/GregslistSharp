<template>
  <div class="card">
    <div class="card-body d-flex justify-content-between align-items-center">
      <h5>{{ job?.company }} / {{ job?.jobTitle }}</h5>
      <!-- <div class="align-items-center d-flex gap-2">
        <img :src="seller.picture" :alt="seller.name" :title="seller.name" height="30" class="rounded">
        <i class="mdi mdi-delete-forever fs-4 selectable rounded" @click.stop="$emit('deleteClassified')"
          v-if="account.id == seller.id"></i>
      </div> -->
    </div>
  </div>
</template>


<script>
import { AppState } from "../AppState.js";
import { computed } from '@vue/reactivity';

export default {
  props: {
    job: { type: Object, required: true },
    // seller: { type: SellerProfile, required: true }
  },
  setup(props, { emit }) {
    return {
      // account: computed(() => AppState.account),
      // deleteClassified() {
      //   emit('deleteClassified')
      // }
    }
  }
}
</script>


<style lang="scss" scoped>

</style>